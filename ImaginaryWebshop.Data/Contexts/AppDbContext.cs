namespace ImaginaryWebshop.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<ProductOrderModel> ProductsInOrder { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<WarehouseModel> Warehouse { get; set; }
    }
}
