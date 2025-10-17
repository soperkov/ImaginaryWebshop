namespace ImaginaryWebshop.Data.Dtos
{
    public class OrderCreateDto
    {
        public Guid UserId { get; set; }
        public List<ProductOrderCreateDto> Items { get; set; } = new();
    }
}