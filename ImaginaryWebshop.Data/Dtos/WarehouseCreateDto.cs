namespace ImaginaryWebshop.Data.Dtos
{
    public class WarehouseCreateDto
    {
        public Guid ProductId { get; set; }
        public int StockQuantity { get; set; }
        public string Position { get; set; } = string.Empty;
    }
}
