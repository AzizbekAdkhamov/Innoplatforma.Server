using Innoplatforma.Server.Service.Mappers;
using Microsoft.EntityFrameworkCore;
using Innoplatforma.Server.Api.Extentions;
using Innoplatforma.Server.Data.DbContexts;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using Innoplatforma.Server.Service.Helpers;

namespace Innoplatforma.Server.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<InnoPlatformDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddCustomService();

        builder.Services.AddMemoryCache();

        // JWT service
        builder.Services.AddSwaggerService();

        builder.Services.AddRateLimiter(rateLimiterOptions =>
        {
            rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
            {
                options.Window = TimeSpan.FromSeconds(10);
                options.PermitLimit = 5;
                options.QueueLimit = 5;
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
            });

            rateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            rateLimiterOptions.OnRejected = async (context, token) =>
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                await context.HttpContext.Response.WriteAsync(
                    "Too many request. Please try again later.", cancellationToken:  token);
            };
        });

        

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        if(app.Services.GetRequiredService<IWebHostEnvironment>() != null)
        {
            var service = app.Services.GetRequiredService<IWebHostEnvironment>();
            WebHostEnviromentHelper.WebRootPath = service.WebRootPath;
        }

        app.UseRateLimiter();

        app.MapControllers();

        app.Run();
    }
}
