namespace ImaginaryWebshop.Data.Models
{
    public class WarehouseModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StockQuantity { get; set; }
        public int Position { get; set; }
    }
}
