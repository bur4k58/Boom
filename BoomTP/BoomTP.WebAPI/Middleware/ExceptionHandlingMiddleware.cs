using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Threading.Tasks;
using AP.BoomTP.Application.Exceptions;
using Microsoft.AspNetCore.Http;

namespace AP.BoomTP.WebAPI.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var response = new ErrorResponseInfo();
            response.Message = ex.Message;
            switch (ex)
            {
                case Application.Exceptions.ValidationException:
                case ZoneException:
                case ScheduleTaskException:
                case ScheduleException:
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                case RelationNotFoundException:
                case KeyNotFoundException:
                    response.StatusCode = StatusCodes.Status404NotFound;
                    break;
                default:
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }
            context.Response.StatusCode = response.StatusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}

public class ErrorResponseInfo
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
}
