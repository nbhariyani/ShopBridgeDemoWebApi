using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Description;

namespace ShopBridgeAPI.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(string.Format(@"{0}\ShopBridgeAPI.WebApi.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ShopBridge Web.API",
                    Description = "This is Demo Web API for interview.",
                    Contact = new OpenApiContact
                    {
                        Name = "Naresh Hariyani",
                        Email = "nbhariyani@gmail.com"
                    }
                });
                c.OperationFilter<RemoveQueryApiVersionParamOperationFilter>();                
            });
        }

        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = false;
            });
        }
    }

    public class RemoveQueryApiVersionParamOperationFilter : Swashbuckle.AspNetCore.SwaggerGen.IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var versionParameter = operation.Parameters
                .FirstOrDefault(p => p.Name == "version" && p.In == ParameterLocation.Path);

            if (versionParameter != null)
                operation.Parameters.Remove(versionParameter);
        }
    }
}
