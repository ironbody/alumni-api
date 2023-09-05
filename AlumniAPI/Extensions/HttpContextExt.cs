using System.Security.Claims;

namespace AlumniAPI.Extensions;

public static class HttpContextExt
{
    public static string GetUserEmail(this HttpContext httpContext)
    {
        return httpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Email)?.Value ?? string.Empty;
    }
    public static string GetUserName(this HttpContext httpContext)
    {
        return httpContext.User.Claims.Single(x => x.Type == "name").Value;
    }
}