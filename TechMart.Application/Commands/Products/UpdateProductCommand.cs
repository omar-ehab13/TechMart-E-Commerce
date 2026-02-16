using MediatR;
using TechMart.Application.DTOs.Products;

namespace TechMart.Application.Commands.Products;

public class UpdateProductCommand : IRequest<bool>
{
    public UpdateProductDto Product { get; set; }

    public UpdateProductCommand(UpdateProductDto product)
    {
        Product = product;
    }
}
