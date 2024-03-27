using Events.API;
using Events.Application;
using Events.Domain;
using Events.Infrastructure;
using Common.Presentation;


WebApplicationBuilder lEventsApplicationBuilder = WebApplication.CreateBuilder(args);

await lEventsApplicationBuilder.ConfigureInfrastructureAsync();
lEventsApplicationBuilder.Services.RegisterDomainServices();
lEventsApplicationBuilder.Services.RegisterApplicationServices();
lEventsApplicationBuilder.ConfigureCommonPresentation();
lEventsApplicationBuilder.ConfigurePresentation();

var lEventsApplication = lEventsApplicationBuilder.Build();

await lEventsApplication.UseInfrastructure();
lEventsApplication.UsePresentation();

await lEventsApplication.RunAsync();
