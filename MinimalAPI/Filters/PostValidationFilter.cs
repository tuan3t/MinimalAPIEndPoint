
using Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace MinimalAPI.Filters
{
    public class PostValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
            var post = context.GetArgument<Post>(0);
            if (String.IsNullOrEmpty(post.Content))
                return await Task.FromResult(Results.BadRequest("Post not valid"));

            return await next(context);
        }
    }
}
