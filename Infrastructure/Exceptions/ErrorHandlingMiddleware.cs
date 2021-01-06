using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public IExceptionMapper exceptionMapper { get; }

        public ErrorHandlingMiddleware(IExceptionMapper exceptionMapper)
        {
            this.exceptionMapper = exceptionMapper;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                var exceptionResponse = exceptionMapper.Map(e);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)exceptionResponse.StatusCode;
                await context.Response.WriteAsync($"{exceptionResponse.Code} : {exceptionResponse.Message}");
            }
        }
    }
}