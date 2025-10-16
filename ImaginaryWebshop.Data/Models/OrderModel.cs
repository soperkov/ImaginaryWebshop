namespace ImaginaryWebshop.Data.Models
{
    public class OrderModel
    {
        [Key] public Guid Id { get; set; }
        [ForeignKey(nameof(User))] public Guid UserId { get; set; }
        public UserModel User { get; set; } = null!;
        [ForeignKey(nameof(Product))] public Guid ProductId { get; set; }
        public ProductModel Product { get; set; } = null!;
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
