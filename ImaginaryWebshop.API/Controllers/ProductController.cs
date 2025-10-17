namespace ImaginaryWebshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody]ProductCreateDto dto)
        {
            var id = await _productService.CreateProductAsync(dto);
            return Ok(id);
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody]ProductUpdateDto dto)
        {
            await _productService.UpdateProductAsync(productId, dto);
            return NoContent();
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductDetailsDto>> GetProductDetails(Guid productId)
        {
            var product = await _productService.GetProductDetailsAsync(productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDetailsDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }
    }
}
