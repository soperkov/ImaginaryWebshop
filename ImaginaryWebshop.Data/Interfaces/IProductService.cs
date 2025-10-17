namespace ImaginaryWebshop.Data.Interfaces
{
    public interface IProductService
    {
        Task<Guid> CreateProductAsync(ProductCreateDto product);
        Task UpdateProductAsync(Guid id, ProductUpdateDto product);
        Task<ProductDetailsDto> GetProductDetailsAsync(Guid id);
        Task<List<ProductDetailsDto>> GetAllProductsAsync();
    }
}
