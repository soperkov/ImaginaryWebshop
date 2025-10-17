namespace ImaginaryWebshop.Data.Dtos
{
    public class ProductOrderCreateDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
