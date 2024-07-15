using Microsoft.EntityFrameworkCore;
using Ejercicio4Modulo3.Repository;
using Ejercicio4Modulo3.Services;
using Ejercicio4Modulo3.Services.Interfaces;
using Ejercicio4Modulo3.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Ejercicio4Modulo3
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

            // Inyección Dependencias
            var connection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<Ejercicio4Modulo3Context>(opt =>
                    opt.UseSqlServer(connection));

            //Contenedor de dependencias
            builder.Services.AddScoped<IProveedorService, ProveedorService>();

            builder.Services.AddScoped<LogTransacciones>();

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

            app.UseMiddleware<LogTransacciones>();

            app.Run();
        }
    }
}