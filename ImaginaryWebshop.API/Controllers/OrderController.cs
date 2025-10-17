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
        public async Task<ActionResult<OrderDetailsDto>> GetOrderDetails([FromQuery]Guid orderId, Guid userId)
        {
            var order = await _orderService.GetOrderDetailsAsync(orderId, userId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
