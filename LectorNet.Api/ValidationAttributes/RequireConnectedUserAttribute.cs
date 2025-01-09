using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LectorNet.Api.ValidationAttributes;

// Header logging middleware filter attribute
public class RequireConnectedUserAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var headers = context.HttpContext.Request.Headers;

        var userIdFromHeaders = headers.TryGetValue("X-User-Id", out var userId);

        if (!userIdFromHeaders || string.IsNullOrEmpty(userId) || !IsValidGuid(userId!))
        {
            context.Result = new UnauthorizedObjectResult(new
            {
                error = "Non autorisé",
                message = "Vous devez être authentifié pour effectuer cette action"
            });
            return;
        }

        await next();
    }

    private static bool IsValidGuid(string guidString) => Guid.TryParse(guidString, out _);
}
