namespace ImaginaryWebshop.Data.Models
{
    public class OrderModel
    {
        [Key] public Guid Id { get; set; }
        [ForeignKey(nameof(User))] public Guid UserId { get; set; }
        public UserModel User { get; set; } = null!;
        public List<ProductOrderModel> Products { get; set; } = new();
        public DateTime OrderDate { get; set; }
    }
}
