using AP.BoomTP.WebAPI.Middleware;
using Microsoft.AspNetCore.Builder;

namespace AP.BoomTP.WebAPI.Extensions;

public static class Registrator
{
    public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        return app;
    }
}
