using MediatR;
using TechMart.Application.Commands.Products;
using TechMart.Domain.Entities;
using TechMart.Domain.Enums;
using TechMart.Domain.Interfaces;

namespace TechMart.Application.Handlers.Products.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _productRepository;
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(
        IProductRepository productRepository,
        IInventoryRepository inventoryRepository,
        IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _inventoryRepository = inventoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Product;

        var product = new Product
        {
            SKU = dto.SKU,
            Name = dto.Name,
            Description = dto.Description,
            CategoryId = dto.CategoryId,
            BrandId = dto.BrandId ?? 0, // if BrandId nullable
            Price = dto.Price,
            CostPrice = dto.CostPrice ?? 0,
            IsActive = dto.IsActive,
            IsFeatured = dto.IsFeatured,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "System"
        };

        if (dto.Specifications != null && dto.Specifications.Any())
        {
            foreach (var spec in dto.Specifications)
            {
                product.Specifications.Add(new ProductSpecification
                {
                    Key = spec.SpecName,
                    Value = spec.SpecValue
                });
            }
        }

        await _productRepository.AddAsync(product, cancellationToken);

        var inventory = new Inventory
        {
            Product = product,
            QuantityOnHand = dto.InitialStock,
            QuantityReserved = 0,
            WarehouseLocation = dto.WarehouseLocation ?? "Default",
            ReorderPoint = dto.ReorderPoint,
            ReorderQuantity = dto.ReorderQuantity,
            LastRestockDate = dto.InitialStock > 0 ? DateTime.UtcNow : null
        };

        await _inventoryRepository.AddAsync(inventory, cancellationToken);

        if (dto.InitialStock > 0)
        {
            var transaction = new InventoryTransaction
            {
                TransactionType = InventoryTransactionType.Purchase,
                Inventory = inventory,
                Quantity = dto.InitialStock,
                UnitCost = dto.CostPrice,
                ReferenceNumber = Guid.NewGuid().ToString()
            };

            await _unitOfWork.GetRepository<InventoryTransaction>()
                             .AddAsync(transaction, cancellationToken);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}
