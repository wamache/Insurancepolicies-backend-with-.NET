using Microsoft.AspNetCore.Mvc;  // For ApiController, ControllerBase, HttpPost, IActionResult, etc.
 using Microsoft.EntityFrameworkCore;

public interface IUserService
{
    Task<IActionResult> RegisterUserAsync(RegisterRequest request);
     Task SendVerificationEmailAsync(User user);
}
