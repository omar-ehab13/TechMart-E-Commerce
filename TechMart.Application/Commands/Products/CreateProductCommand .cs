using MediatR;
using TechMart.Application.DTOs.Products;

namespace TechMart.Application.Commands.Products;

public class CreateProductCommand : IRequest<int>
{
    public CreateProductDto Product { get; set; }

    public CreateProductCommand(CreateProductDto product)
    {
        Product = product;
    }
}
