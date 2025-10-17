namespace ImaginaryWebshop.Data.Models
{
    public class ProductOrderModel
    {
        [Key] public Guid Id { get; set; }
        [ForeignKey(nameof(Order))] public Guid OrderId { get; set; }
        public OrderModel Order { get; set; } = null!;
        [ForeignKey(nameof(Product))] public Guid ProductId { get; set; }
        public ProductModel Product { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
