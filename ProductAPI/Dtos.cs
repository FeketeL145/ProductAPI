namespace ProductAPI
{
    public class Dtos
    {
        public record ProductDto(Guid Id, string ProductName, int ProductPrice, DateTimeOffset CreatedTime, DateTimeOffset Modified);

    }
}
