using System.Diagnostics.CodeAnalysis;

namespace App.Web.Infrastructure;

public static class IEndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapGet(this IEndpointRouteBuilder builder, Delegate handler,
        [StringSyntax("Route")] string pattern = "")
    {
        handler.Method.ThrowIfAnonymous();

        builder.MapGet(pattern, handler)
            .WithName(handler.Method.Name);

        return builder;
    }

    public static IEndpointRouteBuilder MapPost(this IEndpointRouteBuilder builder, Delegate handler,
        [StringSyntax("Route")] string pattern = "")
    {
        handler.Method.ThrowIfAnonymous();


        builder.MapPost(pattern, handler)
            .WithName(handler.Method.Name);

        return builder;
    }

    public static IEndpointRouteBuilder MapPut(this IEndpointRouteBuilder builder, Delegate handler,
        [StringSyntax("Route")] string pattern)
    {
        handler.Method.ThrowIfAnonymous();

        builder.MapPut(pattern, handler)
            .WithName(handler.Method.Name);

        return builder;
    }

    public static IEndpointRouteBuilder MapDelete(this IEndpointRouteBuilder builder, Delegate handler,
        [StringSyntax("Route")] string pattern)
    {
        handler.Method.ThrowIfAnonymous();

        builder.MapDelete(pattern, handler)
            .WithName(handler.Method.Name);

        return builder;
    }
}
