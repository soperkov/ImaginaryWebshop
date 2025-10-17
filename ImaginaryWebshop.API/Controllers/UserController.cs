namespace ImaginaryWebshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Guid>> Register([FromBody]RegistrationDto dto)
        {
            try
            {
                var userId = await _userService.RegisterAsync(dto);
                return Ok(userId);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<Guid>> Login([FromBody]UserLoginDto dto)
        {
            var userId = await _userService.LoginAsync(dto);

            if (userId == null)
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }

            return Ok(userId);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDetailsDto>> GetUser(Guid userId)
        {
            var user = await _userService.GetUserAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
