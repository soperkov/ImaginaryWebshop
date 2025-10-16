namespace ImaginaryWebshop.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> RegisterAsync(UserCreateDto user);
        Task<string> LoginAsync(UserLoginDto user);
        Task<UserDetailsDto> GetUserAsync (Guid id);
    }
}
