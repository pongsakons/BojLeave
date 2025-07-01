using BojLeave.Api.Middleware;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace BojLeave.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Services
            builder.Services.AddControllers();
            builder.Services.AddSwaggerDocumentation();
            builder.Services.AddJwtAuthentication();
            builder.Services.AddAuthorization();
            builder.Services.AddCustomCors();
            builder.Services.AddCustomServices();
            builder.Services.AddBojLeaveCoreServices();
            builder.Services.AddDbContext<BojLeave.Infrastructure.BojLeaveDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddValidatorsFromAssemblyContaining<BojLeave.Domain.Validators.UserValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<BojLeave.Application.Validators.LoginRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<BojLeave.Application.Validators.RefreshTokenRequestValidator>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BojLeave API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("AllowAll");
            app.UseCustomExceptionHandler();
            app.MapControllers();

            app.Run();
        }
    }
}
