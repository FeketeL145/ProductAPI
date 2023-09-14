using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using static ProductAPI.Dtos;

namespace ProductAPI.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<ProductDto> products = new()
        {
            new ProductDto(Guid.NewGuid(),"Termék1",2500,DateTimeOffset.UtcNow,DateTimeOffset.UtcNow),
            new ProductDto(Guid.NewGuid(),"Termék2",5500,DateTimeOffset.UtcNow,DateTimeOffset.UtcNow),
            new ProductDto(Guid.NewGuid(),"Termék3",12500,DateTimeOffset.UtcNow,DateTimeOffset.UtcNow),
        };

        [HttpGet]
        public IEnumerable<ProductDto> GetAll()
        {
            return products;
        }
        [HttpGet("{id}")]
        public ProductDto GetById(Guid id)
        {
            var product = products.Where(x => x.Id == id).FirstOrDefault();

            return product;
        }

        [HttpPost]
        public ProductDto PostProduct(CreateProductDto createProduct)
        {
            var product = new ProductDto(Guid.NewGuid(), createProduct.ProductName, createProduct.ProductPrice, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow);

            products.Add(product);
            return product;
        }
        [HttpPut]
        public ProductDto PullProduct(Guid id, UpdateProductDto updateProduct)
        {
            var existingProduct = products.Where(x => x.Id != id).FirstOrDefault();
            var product = existingProduct with
            {
                ProductName = updateProduct.ProductName,
                ProductPrice = updateProduct.ProductPrice,
                ModifiedTime = DateTimeOffset.UtcNow,
            };
            var index = products.FindIndex(x => x.Id == id);
            products[index] = product;
            return product;
        }
        [HttpDelete]
        public string DeleteProduct(Guid id)
        {
            var index = products.FindIndex(x => x.Id == id);
            products.RemoveAt(index);
            var returned = $"Product removed at: {index}";
            return returned;
        }
    }
}
