namespace ImaginaryWebshop.API.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        Task<Guid> IProductService.CreateProductAsync(ProductCreateDto product)
        {
            throw new NotImplementedException();
        }

        Task<List<ProductDetailsDto>> IProductService.GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        Task<ProductDetailsDto> IProductService.GetProductDetailsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task IProductService.UpdateProductAsync(Guid id, ProductUpdateDto product)
        {
            throw new NotImplementedException();
        }
    }
}
