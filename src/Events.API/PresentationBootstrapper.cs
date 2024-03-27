using FluentValidation;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Reflection;
using TGF.CA.Application;
using TGF.CA.Presentation.Middleware;
using TGF.CA.Presentation.MinimalAPI;
using TGF.CA.Presentation;

namespace Events.API
{
    /// <summary>
    /// Provides methods for configuring and using the presentation layer specific services.
    /// </summary>
    public static class PresentationBootstrapper
    {
        /// <summary>
        /// Configures the specific presentation layer required services for this web application.
        /// </summary>
        public static void ConfigurePresentation(this WebApplicationBuilder aWebApplicationBuilder)
        {
            var lXmlDocFileName = $"{Assembly.GetEntryAssembly()?.GetName().Name}.xml";
            var lXmlDocFilePath = Path.Combine(AppContext.BaseDirectory, lXmlDocFileName);

            aWebApplicationBuilder.ConfigureDefaultPresentation(
                new List<string> { lXmlDocFilePath },
                aBaseSwaggerPath: "events-ms",
                aScanMarkerList: typeof(PresentationErrors)
            );
            //aWebApplicationBuilder.Services.AddValidatorsFromAssemblyContaining<MembersSortByValidator>();
            //aWebApplicationBuilder.Services.AddValidatorsFromAssemblyContaining<RolesSortByValidator>();

        }

        /// <summary>
        /// Applies the presentation configurations to the web application and setup the middleware pipeline
        /// </summary>
        public static void UsePresentation(this WebApplication aWebApplication)
        {
            if (aWebApplication.Environment.IsDevelopment() || aWebApplication.Environment.IsStaging())
            {
                aWebApplication.UseSwagger();
                aWebApplication.UseSwaggerUI();
            }
            aWebApplication.MapHealthChecks(TGFEndpointRoutes.health, new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            aWebApplication.UseCustomErrorHandlingMiddleware();
            aWebApplication.UseRouting();//UseRouting() must be called before UseAuthentication() and UseAuthorization() which is UseIdentity().
            aWebApplication.UseIdentity();

            aWebApplication.MapHealthChecksUI(options => options.UIPath = TGFEndpointRoutes.healthUi);
            aWebApplication.UseEndpointDefinitions();
            aWebApplication.Run();
        }

    }
}
