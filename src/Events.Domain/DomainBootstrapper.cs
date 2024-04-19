using Events.Domain.Contracts.Services;
using Events.Domain.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Domain
{
    /// <summary>
    /// Provides methods for configuring and using the domain layer specific services.
    /// </summary>
    public static class DomainBootstrapper
    {
        /// <summary>
        /// Configures the specific domain layer required services for this web application.
        /// </summary>
        /// <param name="aServiceList"></param>
        public static void RegisterDomainServices(this IServiceCollection aServiceList)
        {
            aServiceList.AddValidatorsFromAssemblyContaining<EventManagerValidator>();
        }
    }
}
