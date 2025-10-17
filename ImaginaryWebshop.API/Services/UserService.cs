namespace ImaginaryWebshop.API.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserDetailsDto?> GetUserAsync(Guid id)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u =>  u.Id == id);

            if (user == null)
            {
                throw new KeyNotFoundException("User doesn't exist.");
            }

            return new UserDetailsDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
        }

        public async Task<Guid?> LoginAsync(UserLoginDto dto)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == dto.UsernameOrEmail || u.Username == dto.UsernameOrEmail);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null;

            return user.Id;
        }

        public async Task<Guid> RegisterAsync(RegistrationDto dto)
        {
            var exists = await _context.Users
                .AnyAsync(u => u.Email == dto.Email || u.Username == dto.Username);
            if (exists)
                throw new InvalidOperationException("User with this email or username already exists.");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new UserModel
            {
                Id = Guid.NewGuid(),
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = passwordHash
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }
    }
}
