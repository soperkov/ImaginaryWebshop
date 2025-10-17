namespace ImaginaryWebshop.Data.Interfaces
{
    public interface IOrderService
    {
        Task<Guid> CreateOrderAsync(OrderCreateDto orderCreateDto);
        Task<OrderDetailsDto> GetOrderDetailsAsync(Guid orderId, Guid userId);
        Task<List<OrderDetailsDto>> GetAllOrdersAsync(Guid userId);
    }
}
