namespace ImaginaryWebshop.Data.Dtos
{
    public class UserDetailsDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
