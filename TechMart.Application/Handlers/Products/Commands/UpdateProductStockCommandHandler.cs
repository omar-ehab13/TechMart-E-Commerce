using MediatR;
using Microsoft.EntityFrameworkCore;
using TechMart.Application.Commands.Products;
using TechMart.Domain.Entities;
using TechMart.Domain.Interfaces;

namespace TechMart.Application.Handlers.Products.Commands;

public class UpdateProductStockCommandHandler : IRequestHandler<UpdateProductStockCommand, bool>
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductStockCommandHandler(
        IInventoryRepository inventoryRepository,
        IProductRepository productRepository,
        IUnitOfWork unitOfWork)
    {
        _inventoryRepository = inventoryRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateProductStockCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _inventoryRepository
            .GetAllQueryable()
            .FirstOrDefaultAsync(i => i.ProductId == request.ProductId, cancellationToken);

        if (inventory == null)
            return false;

        // Update quantity
        inventory.QuantityOnHand += request.QuantityChange;

        if (request.QuantityChange > 0)
        {
            inventory.LastRestockDate = DateTime.UtcNow;
        }

        await _inventoryRepository.UpdateAsync(inventory);

        // Create transaction record
        var transaction = new InventoryTransaction
        {
            InventoryId = inventory.Id,
            Inventory = inventory,
            TransactionType = Domain.Enums.InventoryTransactionType.Sale,
            Quantity = request.QuantityChange,
            Notes = request.Reason
        };

        await _unitOfWork.GetRepository<InventoryTransaction>().AddAsync(transaction);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
