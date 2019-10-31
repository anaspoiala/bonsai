using System.Security.Claims;
using System.Threading.Tasks;
using Bonsai.Helpers;
using Microsoft.AspNetCore.Http;

namespace Bonsai.WebAPI.Middlewares
{
    public class RequestUserIdMiddleware
    {
        private readonly RequestDelegate next;

        public RequestUserIdMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserInformation userInfo)
        {
            if (context.User.FindFirst(ClaimTypes.Name) != null)
            {
                int userId = int.Parse(context.User.FindFirst(ClaimTypes.Name).Value);
                userInfo.CurrentUserId = userId;
            }
            else
            {
                userInfo.CurrentUserId = -1;
            }

            await next(context);
        }
    }
}
