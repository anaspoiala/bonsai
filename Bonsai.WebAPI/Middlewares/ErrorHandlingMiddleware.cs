using System;
using System.Net;
using System.Threading.Tasks;
using Bonsai.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Bonsai.WebAPI.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode code;
            
            if (ex is AccountNotFoundException || 
                ex is ItemNotFoundException || 
                ex is PantryNotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }
            else if (ex is NotLoggedInException)
            {
                code = HttpStatusCode.Unauthorized;
            }
            else if (ex is DuplicateItemException)
            {
                code = HttpStatusCode.Conflict;
            }
            else if (ex is NotImplementedException)
            {
                code = HttpStatusCode.NotImplemented;
            }
            else
            {
                code = HttpStatusCode.InternalServerError;
            }

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
