using Microsoft.AspNetCore.Components.Web;

namespace ProductAPI
{
    public class Dtos
    {
        public record ProductDto(Guid Id, string ProductName, int ProductPrice, DateTimeOffset CreatedTime, DateTimeOffset ModifiedTime);
        public record CreateProductDto(string ProductName, int ProductPrice);
        public record UpdateProductDto(string ProductName, int ProductPrice);
        public record DeleteProductDto(Guid Id);
    }
}
