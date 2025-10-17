namespace ImaginaryWebshop.API.Services
{
    public class ProductService : IProductService
    {
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
