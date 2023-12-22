using Innoplatforma.Server.Service.Mappers;
namespace Innoplatforma.Server.Api
using Microsoft.EntityFrameworkCore;
using Innoplatforma.Server.Api.Extentions;
using Innoplatforma.Server.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

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


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
      
        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddCustomService();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
