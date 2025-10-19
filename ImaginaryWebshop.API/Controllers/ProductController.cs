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

        [HttpPost("image")]
        public async Task<ActionResult<string>> UploadImage([FromForm] IFormFile file, [FromQuery] Guid? productId, [FromServices] IWebHostEnvironment env,
        [FromServices] IUploadsService uploads, [FromServices] IProductService products)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file.");
            }

            string? oldUrl = null;
            if (productId.HasValue)
            {
                var existing = await products.GetProductDetailsAsync(productId.Value);
                oldUrl = existing?.PictureUrl;
            }

            await using var stream = file.OpenReadStream();
            var url = await uploads.SaveProductImageAsync(stream, file.FileName, env.WebRootPath!, oldUrl);

            if (productId.HasValue)
                await products.UpdateProductAsync(productId.Value, new ProductUpdateDto { PictureUrl = url });

            return Ok(url);
        }
    }
}
