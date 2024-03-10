using System.ComponentModel.DataAnnotations;

namespace AutoMarketProject.Presentation.Users;

public record UserLoginDto(
    [Required(ErrorMessage = "Email is required")] string Email,
    [Required(ErrorMessage = "Password is required")]string Password);