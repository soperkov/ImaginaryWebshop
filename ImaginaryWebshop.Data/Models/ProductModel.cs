namespace ImaginaryWebshop.Data.Models
{
    public class ProductModel
    {
        [Key] public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public string? PictureUrl { get; set; }
    }
}
