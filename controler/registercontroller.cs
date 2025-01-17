// //  using Microsoft.AspNetCore.Mvc;  // For ApiController, ControllerBase, HttpPost, IActionResult, etc.
// //  using Microsoft.EntityFrameworkCore;


// // [ApiController]
// // [Route("api/[controller]")]
// // public class RegistrationController : ControllerBase
// // {
// //     // private readonly IUserService _userService;
// //      private readonly IUserRepository _userRepository;
// //     private readonly IUserService _userService;

// //     public RegisterController(IUserRepository userRepository, IUserService userService)
// //     {
// //         _userRepository = userRepository;
// //         _userService = userService;
// //     }


// //     // Dependency Injection of IUserService
// //     public RegistrationController(IUserService userService)
// //     {
// //         _userService = userService;
// //     }

// //     // [HttpPost("register")]
// //     // public async Task<IActionResult> Register([FromBody] RegisterRequest request)
// //     // {
// //     //     // Call the UserService to handle the registration logic
// //     //     return await _userService.RegisterUserAsync(request);
// //     // }
// //     [HttpPost("register")]
// // public async Task<IActionResult> Register(RegisterRequest request)
// // {
// //     var user = new User
// //     {
// //         FirstName = request.FirstName,
// //         LastName = request.LastName,
// //         Email = request.Email,
// //         Password = request.Password // Ensure you hash the password!
// //     };

// //     await _userRepository.AddUserAsync(user);

// //     // Send verification email
// //     await _userService.SendVerificationEmailAsync(user);

// //     return Ok("Registration successful. Please check your email for verification.");
// // }
// // }


// using Microsoft.AspNetCore.Mvc; // For ApiController, ControllerBase, HttpPost, IActionResult, etc.
// using Microsoft.EntityFrameworkCore;

// [ApiController]
// [Route("api/[controller]")]
// public class RegistrationController : ControllerBase
// {
//     private readonly IUserRepository _userRepository;
//     private readonly IUserService _userService;

//     // Constructor with Dependency Injection
//     public RegistrationController(IUserRepository userRepository, IUserService userService)
//     {
//         _userRepository = userRepository;
//         _userService = userService;
//     }

//     [HttpPost("register")]
//     public async Task<IActionResult> Register([FromBody] RegisterRequest request)
//     {
//         // Validate request
//         if (!ModelState.IsValid)
//         {
//             return BadRequest(ModelState);
//         }

//         // Check if the user already exists
//         var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
//         if (existingUser != null)
//         {
//             return Conflict("A user with this email already exists.");
//         }

//         // Create new user
//         var user = new User
//         {
//             FirstName = request.FirstName,
//             LastName = request.LastName,
//             Email = request.Email,
//             Password = BCrypt.Net.BCrypt.HashPassword(request.Password) // Hash the password
//         };

//         // Save user to the repository
//         await _userRepository.AddUserAsync(user);

//         // Send verification email
//         await _userService.SendVerificationEmailAsync(user);

//         return Ok("Registration successful. Please check your email for verification.");
//     }
// }

using Microsoft.AspNetCore.Mvc; // For ApiController, ControllerBase, HttpPost, IActionResult, etc.
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class RegistrationController : ControllerBase
{
private readonly IUserRepository _userRepository;
private readonly IUserService _userService;

// Constructor with Dependency Injection
public RegistrationController(IUserRepository userRepository, IUserService userService)
{
_userRepository = userRepository;
_userService = userService;
}

[HttpPost("register")]
public async Task<IActionResult> Register([FromBody] RegisterRequest request)
{
// Validate request
if (!ModelState.IsValid)
{
return BadRequest(ModelState);
}

// Check if the user already exists
var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
if (existingUser != null)
{
return Conflict("A user with this email already exists.");
}

// Create new user
var user = new User
{
FirstName = request.FirstName,
LastName = request.LastName,
Email = request.Email,
Password = BCrypt.Net.BCrypt.HashPassword(request.Password) // Hash the password
};

// Save user to the repository
await _userRepository.AddUserAsync(user);

// Send verification email
await _userService.SendVerificationEmailAsync(user);

return Ok("Registration successful. Please check your email for verification.");
}
}