using Microsoft.AspNetCore.Builder;
using Common.Infrastructure;
using Events.Infrastructure.DataAccess.DbContexts;
using TGF.CA.Infrastructure.DB.PostgreSQL;
using Events.Application.Contracts.Repositories;
using Events.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using TGF.CA.Infrastructure;
using Events.Domain.Contracts.Services;
using Events.Infrastructure.Services;
using Events.Domain.Contracts.Repositories;
using Common.Application.Contracts.Services;
using Common.Infrastructure.Communication.HTTP;

namespace Events.Infrastructure
{
    /// <summary>
    /// Provides methods for configuring and using the infrastructure layer specific services.
    /// </summary>
    public static class InfrastructureBootstrapper
    {

        /// <summary>
        /// Configures the specific infrastructure layer required services for this web application.
        /// </summary>
        /// <param name="aWebApplicationBuilder">The web application builder.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task ConfigureInfrastructureAsync(this WebApplicationBuilder aWebApplicationBuilder)
        {
            await aWebApplicationBuilder.ConfigureCommonInfrastructureAsync();

            await aWebApplicationBuilder.Services.AddPostgreSQL<EventsDbContext>("EventsDb");
            aWebApplicationBuilder.Services.AddScoped<IEventRepository, EventRespository>();
            aWebApplicationBuilder.Services.AddScoped<ITagRepository, TagRepository>();

            aWebApplicationBuilder.Services.AddScoped<IExternalPermissionsService, ExternalPermissionsService>();
            aWebApplicationBuilder.Services.AddScoped<IMembersCommunicationService, MembersCommunicationService>();

            //aWebApplicationBuilder.Services.AddHostedService<StartupHostedService>();

            //aWebApplicationBuilder.Services.AddHttpClient();
            //aWebApplicationBuilder.Services.AddScoped<IRolesInfrastructureService, RolesInfrastructureService>();
            //aWebApplicationBuilder.Services.AddScoped<IGameVerificationService, GameVerificationService>();
            aWebApplicationBuilder.ConfigureCommunication();

        }

        /// <summary>
        /// Configure the communication-related services such as message broker related services or direct communication related services
        /// </summary>
        public static void ConfigureCommunication(this WebApplicationBuilder aWebApplicationBuilder)
        {
            //aWebApplicationBuilder.Services.AddScoped<ISwarmBotCommunicationService, SwarmBotCommunicationService>();

            //aWebApplicationBuilder.Services.AddServiceBusIntegrationPublisher();

            //aWebApplicationBuilder.Services.AddMessageHandlersInAssembly<MemberRenameHandler>();
            //aWebApplicationBuilder.Services.AddServiceBusIntegrationConsumer();
        }

        /// <summary>
        /// Applies the infrastructure configurations to the web application.
        /// </summary>
        /// <param name="aWebApplication">The Web application instance.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task UseInfrastructure(this WebApplication aWebApplication)
        {
            await aWebApplication.UseCommonInfrastructure();
            await aWebApplication.UseMigrations<EventsDbContext>();
        }

    }
}
