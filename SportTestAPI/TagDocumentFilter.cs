using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SportTestAPI
{
    public class TagDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            if (swaggerDoc.Tags == null)
                swaggerDoc.Tags = new List<OpenApiTag>();

            //Add custom tags

            swaggerDoc.Tags.Add(new OpenApiTag { Name = "SportsTestAPI", Description = "API related to Sports Management" });
            swaggerDoc.Tags.Add(new OpenApiTag { Name = "Auth", Description = "Authentication APIs for login and user management" });
        }
    }
}
