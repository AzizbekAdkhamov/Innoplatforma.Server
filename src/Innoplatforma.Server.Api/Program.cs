
<<<<<<< Updated upstream
namespace Innoplatforma.Server.Api
=======
using Innoplatforma.Server.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Innoplatforma.Server.Api.Extentions;

namespace Innoplatforma.Server.Api;

public class Program
>>>>>>> Stashed changes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

<<<<<<< Updated upstream
            app.Run();
=======
        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddCustomService();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
>>>>>>> Stashed changes
        }
    }
}
