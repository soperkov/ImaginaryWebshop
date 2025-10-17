namespace ImaginaryWebshop.Data.Interfaces
{
    public interface IUserService
    {
        Task<Guid> RegisterAsync(RegistrationDto user);
        Task<Guid?> LoginAsync(UserLoginDto user);
        Task<UserDetailsDto?> GetUserAsync (Guid id);
    }
}
