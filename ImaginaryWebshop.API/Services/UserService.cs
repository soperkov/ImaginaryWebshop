namespace ImaginaryWebshop.API.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        Task<UserDetailsDto> IUserService.GetUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<string> IUserService.LoginAsync(UserLoginDto user)
        {
            throw new NotImplementedException();
        }

        Task<string> IUserService.RegisterAsync(UserCreateDto user)
        {
            throw new NotImplementedException();
        }
    }
}
