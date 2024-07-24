using Events.Application.Contracts.UseCases.EventManagers;
using Events.Application.Contracts.UseCases.Events;
using Events.Application.UseCases;
using Events.Application.UseCases.EventManagers;
using Events.Application.UseCases.Events;
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
            aServiceList.AddScoped<IListEventsService, ListEventsService>();
            aServiceList.AddScoped<IListEventManagersService, ListEventManagersService>();
            aServiceList.AddScoped<IAddEventManagersService, AddEventManagersService>();
            aServiceList.AddScoped<IDeleteEventManagersService, DeleteEventManagersService>();
            aServiceList.AddScoped<ICreateEventService, CreateEventService>();

        }
    }
}
