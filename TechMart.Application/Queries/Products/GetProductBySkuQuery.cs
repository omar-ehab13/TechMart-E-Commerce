using MediatR;
using TechMart.Application.DTOs.Products;

namespace TechMart.Application.Queries.Products;

public class GetProductBySkuQuery : IRequest<ProductDto?>
{
    public string SKU { get; set; }

    public GetProductBySkuQuery(string sku)
    {
        SKU = sku;
    }
}
