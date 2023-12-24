using System.Threading.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.RateLimiting;
using Innoplatforma.Server.Api.Extentions;
using Innoplatforma.Server.Data.DbContexts;
using Innoplatforma.Server.Service.Mappers;
using Innoplatforma.Server.Service.Helpers;
using Innoplatforma.Server.Api.Middlewares;
using Innoplatforma.Server.Api.Models;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Serilog;

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

        ////Logger
        //var logger = new LoggerConfiguration()
        //    .ReadFrom.Configuration(builder.Configuration)
        //    .Enrich.FromLogContext()
        //    .CreateLogger();
        //builder.Logging.ClearProviders();
        //builder.Logging.AddSerilog(logger);

        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddCustomService();

        builder.Services.AddMemoryCache();

        // JWT service
        builder.Services.AddSwaggerService();
        builder.Services.ConfigureJwt(builder.Configuration);

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

        //Configure api url name
        builder.Services.AddControllers(options =>
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(
                                                new ConfigurationApiUrlName()));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        WebHostEnviromentHelper.WebRootPath = Path.GetFullPath("wwwroot");

        app.UseMiddleware<ExceptionHandlerMiddleWare>();
        app.UseRateLimiter();

        app.MapControllers();

        app.Run();
    }
}
