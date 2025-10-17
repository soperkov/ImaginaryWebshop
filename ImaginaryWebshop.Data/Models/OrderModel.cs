namespace ImaginaryWebshop.Data.Models
{
    [Index(nameof(OrderNumber), IsUnique = true)]
    public class OrderModel
    {
        [Key] public Guid Id { get; set; }
        public string OrderNumber { get; set; } = null!;
        [ForeignKey(nameof(User))] public Guid UserId { get; set; }
        public UserModel User { get; set; } = null!;
        public List<ProductOrderModel> Products { get; set; } = new();
        public double Amount { get; set; }
        public DateTime OrderDate { get; set; }

    }
}