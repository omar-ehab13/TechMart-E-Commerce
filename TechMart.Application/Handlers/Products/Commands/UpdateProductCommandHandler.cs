using MediatR;
using Microsoft.EntityFrameworkCore;
using TechMart.Application.Commands.Products;
using TechMart.Domain.Entities;
using TechMart.Domain.Interfaces;

namespace TechMart.Application.Handlers.Products.Commands;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Product;

        var product = await _productRepository
            .GetAllQueryable()
            .Include(p => p.Specifications) 
            .FirstOrDefaultAsync(p => p.Id == dto.ProductId, cancellationToken);

        if (product == null)
            return false;

        product.SKU = dto.SKU;
        product.Name = dto.Name;
        product.Description = dto.Description;
        product.CategoryId = dto.CategoryId;
        product.BrandId = dto.BrandId ?? 0;
        product.Price = dto.Price;
        product.CostPrice = dto.CostPrice ?? 0;
        product.IsActive = dto.IsActive;
        product.IsFeatured = dto.IsFeatured;
        product.UpdatedAt = DateTime.UtcNow;

        if (dto.Specifications != null)
        {
            // Remove deleted specs
            var specsToRemove = product.Specifications
                .Where(s => dto.Specifications
                    .Any(ds => ds.SpecId == s.Id && ds.IsDeleted))
                .ToList();

            foreach (var spec in specsToRemove)
                product.Specifications.Remove(spec);

            // Update / Add
            foreach (var specDto in dto.Specifications.Where(s => !s.IsDeleted))
            {
                if (specDto.SpecId.HasValue)
                {
                    var existing = product.Specifications
                        .FirstOrDefault(s => s.Id == specDto.SpecId.Value);

                    if (existing != null)
                    {
                        existing.Key = specDto.SpecName;
                        existing.Value = specDto.SpecValue;
                    }
                }
                else
                {
                    product.Specifications.Add(new ProductSpecification
                    {
                        Key = specDto.SpecName,
                        Value = specDto.SpecValue
                    });
                }
            }
        }

        await _productRepository.UpdateAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

}
