using System.Security.Claims;

// public class EmailVerificationMiddleware
// {
//     private readonly RequestDelegate _next;
//     private readonly IUserRepository _userRepository;

//     public EmailVerificationMiddleware(RequestDelegate next, IUserRepository userRepository)
//     {
//         _next = next;
//         _userRepository = userRepository;
//     }

//     public async Task InvokeAsync(HttpContext context)
//     {
//         if (context.User.Identity?.IsAuthenticated == true)
//         {
//             var email = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
//             if (!string.IsNullOrEmpty(email))
//             {
//                 var user = await _userRepository.GetUserByEmailAsync(email);
//                 if (user != null && !user.IsEmailVerified)
//                 {
//                     context.Response.StatusCode = StatusCodes.Status403Forbidden;
//                     await context.Response.WriteAsync("Email not verified.");
//                     return;
//                 }
//             }
//         }

//         await _next(context);
//     }
// }
public class EmailVerificationMiddleware
{
private readonly RequestDelegate _next;

public EmailVerificationMiddleware(RequestDelegate next)
{
_next = next;
}

public async Task InvokeAsync(HttpContext context, IUserRepository userRepository)
{
// Middleware logic here using userRepository
await _next(context);
}
}