namespace ImaginaryWebshop.Data.Models
{
    public class WarehouseModel
    {
        [Key] public Guid Id { get; set; }
        [ForeignKey(nameof(Product))] public Guid ProductId { get; set; }
        public ProductModel Product { get; set; } = null!;
        public int StockQuantity { get; set; }
        public string Position { get; set; } = string.Empty;
    }
}
