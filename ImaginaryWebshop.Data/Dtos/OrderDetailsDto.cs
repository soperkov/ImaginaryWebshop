namespace ImaginaryWebshop.Data.Dtos
{
    public class OrderDetailsDto
    {
        public Guid Id { get; set; }
        public string OrderNumber { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public UserDetailsDto User { get; set; } = null!;
        public List<ProductOrderDetailsDto> Products { get; set; } = new();
        public double Amount { get; set; }
    }
}
