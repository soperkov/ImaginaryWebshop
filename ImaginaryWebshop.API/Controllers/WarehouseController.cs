namespace ImaginaryWebshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateWarehouseItem([FromBody]WarehouseCreateDto dto)
        {
            var itemId = await _warehouseService.CreateWarehouseItemAsync(dto);
            return Ok(itemId);
        }

        [HttpPut("{itemId}")]
        public async Task<IActionResult> UpdateWarehouseItem(Guid itemId,  [FromBody]WarehouseUpdateDto dto)
        {
            await _warehouseService.UpdateWarehouseItemAsync(itemId, dto);
            return NoContent();
        }

        [HttpGet("{itemId}")]
        public async Task<ActionResult<WarehouseDetailsDto>> GetWarehouseItemDetails(Guid itemId)
        {
            var item = await _warehouseService.GetWarehouseItemDetailsAsync(itemId);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpGet]
        public async Task<ActionResult<List<WarehouseDetailsDto>>> GetAll()
        {
            var items = await _warehouseService.GetAllAsync();
            return Ok(items);
        }
    }
}
