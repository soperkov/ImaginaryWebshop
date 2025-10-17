namespace ImaginaryWebshop.Data.Dtos
{
    public class RegistrationDto
    {
        [Required(ErrorMessage = "Username is required!")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Email must be valid.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "You must type in your password.")]
        [MinLength(8, ErrorMessage = "Your password must contain at least 8 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$",
            ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, and one digit.")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "This field must not be empty.")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword { get; set; }
    }
}
