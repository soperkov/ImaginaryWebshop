namespace ImaginaryWebshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateOrder([FromBody]OrderCreateDto dto)
        {
            var id = await _orderService.CreateOrderAsync(dto);
            return Ok(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDetailsDto>>> GetAllOrders([FromQuery]Guid userId)
        {
            var orders = await _orderService.GetAllOrdersAsync(userId);
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderDetailsDto>> GetOrderDetails([FromRoute]Guid orderId, [FromQuery]Guid userId)
        {
            try
            {
                var order = await _orderService.GetOrderDetailsAsync(orderId, userId);
                return Ok(order);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{orderId}/items/{productId}")]
        public async Task<ActionResult<ProductOrderDetailsDto>> GetOrderItem([FromRoute]Guid orderId,[FromRoute]Guid productId,[FromQuery]Guid userId)
        {
            var item = await _orderService.GetOrderItemAsync(orderId, productId, userId);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
