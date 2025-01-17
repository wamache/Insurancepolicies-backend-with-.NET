using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

// public class Startup
// {
//     public Startup(IConfiguration configuration)
//     {
//         Configuration = configuration;
//     }

//     public IConfiguration Configuration { get; }

//     public void ConfigureServices(IServiceCollection services)
//     {
//         // Add Controllers
//         services.AddControllers();

//         // Configure DbContext
//         services.AddDbContext<InsurancePolicyContext>(options =>
//             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

//         // Register Repositories
//         services.AddScoped<IUserRepository, UserRepository>();
//         services.AddScoped<IInsurancePolicyRepository, InsurancePolicyRepository>();

//         // Add Swagger
//         services.AddSwaggerGen(options =>
//         {
//             options.SwaggerDoc("v1", new OpenApiInfo { Title = "API Documentation", Version = "v1" });
//         });
//     }

//     public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//     {
//         if (env.IsDevelopment())
//         {
//             app.UseDeveloperExceptionPage();
//         }

//         // Enable Swagger
//         app.UseSwagger();
//         app.UseSwaggerUI(c =>
//         {
//             c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Documentation v1");
//             c.RoutePrefix = string.Empty;
//         });

//         // Use Middleware
//         app.UseRouting();
//         app.UseMiddleware<EmailVerificationMiddleware>();
//         app.UseAuthentication();
//         app.UseAuthorization();

//         app.UseEndpoints(endpoints =>
//         {
//             endpoints.MapControllers();
//         });
//     }
// }
public class Startup
{
	public Startup(IConfiguration configuration)
{
Configuration = configuration;
}

public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container.
        services.AddControllers();
        
// Configure DbContext
services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories
// services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IInsurancePolicyRepository, InsurancePolicyRepository>();

// Register Services
services.AddScoped<IInsurancePolicyService, InsurancePolicyServiceImpl>();

        // Add Swagger for API documentation
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "API Documentation",
                Version = "v1"
            });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        // Use custom middleware
        app.UseMiddleware<EmailVerificationMiddleware>();


        // Enable Swagger
        app.UseSwagger();

        // Enable Swagger UI
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Documentation v1");
            options.RoutePrefix = string.Empty; // Optional: serve Swagger at the root of the app
        });

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}