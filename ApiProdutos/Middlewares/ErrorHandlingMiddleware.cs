using System.Net;
using System.Text.Json;
using ApiProdutos.Exceptions;
using ApiProdutos.Models;

namespace ApiProdutos.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BadRequestException ex)
        {
            await HandleException(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (Exception )
        {
            await HandleException(context, HttpStatusCode.InternalServerError, "Ocorreu um erro inesperado.");
        }
    }

    private static Task HandleException(HttpContext context, HttpStatusCode statusCode, string mensagem)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var result = JsonSerializer.Serialize(new 
        {
            mensagem = mensagem
        });

        return context.Response.WriteAsync(result);
    }
}