namespace ImaginaryWebshop.Data.Interfaces
{
    public interface ICartService
    {
        Task<CartDetailsDto> GetCartAsync(Guid userId);
        Task AddToCartAsync(Guid userId, AddToCartDto dto);
        Task UpdateCartAsync(Guid userId, UpdateCartDto dto);
        Task RemoveItemAsync(Guid userId, Guid productId);
        Task ClearCartAsync(Guid userId);
        Task<Guid> Checkout(Guid userId);
    }
}
