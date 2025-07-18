using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BojLeave.Api.Middleware
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "BojLeave API", Version = "v1" });
            });
            return services;
        }

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // ตัวอย่าง: ลงทะเบียน service เพิ่มเติม
            services.AddScoped<IDateTimeService, DateTimeService>();
            return services;
        }

        public static IServiceCollection AddBojLeaveCoreServices(this IServiceCollection services)
        {
            // Register core application services here
            services.AddScoped<BojLeave.Application.ILoginService, BojLeave.Application.LoginService>();
            services.AddSingleton<BojLeave.Application.IJwtTokenGenerator, BojLeave.Application.JwtTokenGenerator>();
            // Register SQL Server DbContext
            services.AddDbContext<BojLeave.Infrastructure.BojLeaveDbContext>(options =>
                options.UseSqlServer("YourConnectionStringHere"));
            // Register SQL Server repository
            services.AddScoped<BojLeave.Domain.Repositories.IUserRepository, BojLeave.Infrastructure.Repositories.UserRepository>();
            return services;
        }

        public interface IDateTimeService
        {
            DateTime Now { get; }
        }

        public class DateTimeService : IDateTimeService
        {
            public DateTime Now => DateTime.Now;
        }
    }
}
