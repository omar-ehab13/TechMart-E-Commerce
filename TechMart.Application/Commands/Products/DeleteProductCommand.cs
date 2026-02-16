using MediatR;

namespace TechMart.Application.Commands.Products;

public class DeleteProductCommand : IRequest<bool>
{
    public int ProductId { get; set; }

    public DeleteProductCommand(int productId)
    {
        ProductId = productId;
    }
}
