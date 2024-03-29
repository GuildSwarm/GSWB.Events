using Events.Application.Contracts.Services;
using Events.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Application
{
    /// <summary>
    /// Provides methods for configuring and using the application layer specific services.
    /// </summary>
    public static class ApplicationBootstrapper
    {
        /// <summary>
        /// Configures the specific application layer required services for this web application.
        /// </summary>
        /// <param name="aServiceList"></param>
        public static void RegisterApplicationServices(this IServiceCollection aServiceList)
        {
            aServiceList.AddScoped<IEventsService, EventsService>();
        }
    }
}
