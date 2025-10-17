namespace ImaginaryWebshop.Data.Dtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public string Category { get; set; } = null!;
    }
}
