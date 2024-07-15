using Ejercicio4Modulo3.Domain.Entities;
using Ejercicio4Modulo3.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio4Modulo3.Middlewares
{
    public class LogTransacciones : IMiddleware
    {
        private readonly Ejercicio4Modulo3Context _dbcontext;

        public LogTransacciones(Ejercicio4Modulo3Context dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task InvokeAsync(HttpContext httpcontext, RequestDelegate next)
        {

            await next(httpcontext);

            var log = new Logs
            {
                Fecha = DateTime.Now,
                Path = httpcontext.Request.Path,
                Method = httpcontext.Request.Method,
                Success = httpcontext.Response.StatusCode < 400 ? true : false
            };

            await _dbcontext.Logs.AddAsync(log);
            await _dbcontext.SaveChangesAsync();

        }
    }
}
