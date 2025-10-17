namespace ImaginaryWebshop.API.Services
{
    public class UserService : IUserService
    {
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
