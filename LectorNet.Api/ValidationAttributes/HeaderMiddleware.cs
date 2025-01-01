using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LectorNet.Api.ValidationAttributes;

// Header logging middleware filter attribute
public class RequireConnectedUserAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var headers = context.HttpContext.Request.Headers;

        if (!headers.TryGetValue("X-User-Id", out var userId) || 
            string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out _))
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
    
    public static bool IsValidGuid(string guidString) => Guid.TryParse(guidString, out _);
}
