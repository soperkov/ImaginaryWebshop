namespace ImaginaryWebshop.Data.Dtos
{
    public class WarehouseDetailsDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int StockQuantity { get; set; }
        public string Position { get; set; } = string.Empty;
    }
}
