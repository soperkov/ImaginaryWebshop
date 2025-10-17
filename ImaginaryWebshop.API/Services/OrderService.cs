namespace ImaginaryWebshop.API.Services
{
    public class OrderService : IOrderService
    {
        Task<Guid> IOrderService.CreateOrderAsync(OrderCreateDto orderCreateDto)
        {
            throw new NotImplementedException();
        }

        Task<List<OrderDetailsDto>> IOrderService.GetAllOrdersAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        Task<OrderDetailsDto> IOrderService.GetOrderDetailsAsync(Guid orderId, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
