
namespace ImaginaryWebshop.API.Services
{
    public class CartService : ICartService
    {
        private readonly AppDbContext _context;
        public CartService(AppDbContext context)
        {
            _context = context;
        }

        public Task AddToCartAsync(Guid userId, AddToCartDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Checkout(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task ClearCartAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<CartDetailsDto> GetCartAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveItemAsync(Guid userId, Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCartAsync(Guid userId, UpdateCartDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
