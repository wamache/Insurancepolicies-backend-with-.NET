 using Microsoft.AspNetCore.Mvc;  // For ApiController, ControllerBase, HttpPost, IActionResult, etc.
 using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class VerifyEmailController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public VerifyEmailController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("verify-email")]
    public async Task<IActionResult> VerifyEmail(string token, string email)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user == null || user.EmailVerificationToken != token || user.EmailVerificationTokenExpires < DateTime.UtcNow)
        {
            return BadRequest("Invalid or expired token.");
        }

        // Verify the user's email
        user.IsEmailVerified = true;
        user.EmailVerificationToken = null;
        user.EmailVerificationTokenExpires = null;
        await _userRepository.UpdateUserAsync(user);

        return Ok("Email successfully verified!");
    }
}
