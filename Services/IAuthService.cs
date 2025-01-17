// Services/IAuthService.cs
public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
}
