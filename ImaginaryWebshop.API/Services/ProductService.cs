namespace ImaginaryWebshop.API.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateProductAsync(ProductCreateDto dto)
        {
            var product = new ProductModel
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Category = dto.Category,
                PictureUrl = dto.PictureUrl
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<List<ProductDetailsDto>> GetAllProductsAsync()
        {
            var products = await _context.Products
                .AsNoTracking()
                .ToListAsync();
            return products.Select(p => new ProductDetailsDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Category = p.Category,
                PictureUrl = p.PictureUrl
            }).ToList();
        }

        public async Task<ProductDetailsDto> GetProductDetailsAsync(Guid id)
        {
            var product = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                throw new KeyNotFoundException("Product not found");

            return new ProductDetailsDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                PictureUrl = product.PictureUrl
            };
        }

        public async Task UpdateProductAsync(Guid id, ProductUpdateDto dto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            if (!string.IsNullOrEmpty(dto.Category))
            {
                product.Category = dto.Category;
            }
            if (!string.IsNullOrEmpty(dto.Description))
            {
                product.Description = dto.Description;
            }
            if (!string.IsNullOrEmpty(dto.Name))
            {
                product.Name = dto.Name;
            }
            if (dto.Price.HasValue)
            {
                product.Price = dto.Price.Value;
            }
            if (!string.IsNullOrEmpty(dto.PictureUrl))
            {
                product.PictureUrl = dto.PictureUrl;
            }

            await _context.SaveChangesAsync();
        }
    }
}
