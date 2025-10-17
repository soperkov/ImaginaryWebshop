namespace ImaginaryWebshop.Data.Dtos
{
    public class ProductOrderDetailsDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
