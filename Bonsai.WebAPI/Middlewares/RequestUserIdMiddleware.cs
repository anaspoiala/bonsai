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
            Claim userIdClaim = context.User.FindFirst(ClaimTypes.Name);
            if (userIdClaim != null)
            {
                int userId = int.Parse(userIdClaim.Value); 
                userInfo.CurrentUserIdNullable = userId;
            }
            else
            {
                userInfo.CurrentUserIdNullable = null;
            }

            await next(context);
        }
    }
}
