using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Register DbContext with MySQL
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 21))));

        // Register services for dependency injection
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IEmailService, EmailService>();
        builder.Services.AddScoped<IAuthService, AuthService>(); // Register IAuthService here
		builder.Services.AddScoped<IInsurancePolicyService, InsurancePolicyServiceImpl>();
		builder.Services.AddScoped<IInsurancePolicyRepository, InsurancePolicyRepository>();


        // Add controllers for API routes
        builder.Services.AddControllers();

        // Register Swagger and configure API documentation
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "InsurancePolicy API", Version = "v1" });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline
        if (app.Environment.IsDevelopment())
        {
            // Enable Swagger UI in development
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "InsurancePolicy API v1");
            });

            app.UseDeveloperExceptionPage(); // Show developer exception page in development
        }

        // Use HTTPS redirection
        app.UseHttpsRedirection();

        // Use email verification middleware before authorization (if needed)
        app.UseMiddleware<EmailVerificationMiddleware>();

        // Enable authorization (after the email verification middleware)
        app.UseAuthorization();

        // Map API routes to controllers
        app.MapControllers();

        // Run the app
        app.Run();
    }
}
