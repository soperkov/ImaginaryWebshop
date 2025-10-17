namespace ImaginaryWebshop.Data.Dtos
{
    public class OrderDetailsDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public UserDetailsDto User { get; set; } = null!;
        public ProductDetailsDto Product { get; set; } = null!;
    }
}
