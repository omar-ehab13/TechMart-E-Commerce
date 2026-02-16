using MediatR;

namespace TechMart.Application.Commands.Products;

public class UpdateProductStockCommand : IRequest<bool>
{
    public int ProductId { get; set; }
    public int QuantityChange { get; set; }
    public string Reason { get; set; } = string.Empty;

    public UpdateProductStockCommand(int productId, int quantityChange, string reason)
    {
        ProductId = productId;
        QuantityChange = quantityChange;
        Reason = reason;
    }
}
