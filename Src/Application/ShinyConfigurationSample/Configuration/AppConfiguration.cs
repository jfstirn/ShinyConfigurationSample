using Prism.Ioc;
using Microsoft.Extensions.Configuration;

namespace ShinyConfigurationSample.Configuration
{
    internal static class AppConfiguration
    {
        /// <summary>
        /// Build the configuration and add it to the DI Container.
        /// </summary>
        /// <param name="containerRegistry"></param>
        /// <returns></returns>
        internal static IConfiguration AddConfiguration(this IContainerRegistry containerRegistry)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonPlatformBundle("appsettings.json");

            // Let the builder do it's job
            var configuration = builder.Build();
            // ... and register the configuration into the di container
            containerRegistry.RegisterInstance<IConfiguration>(configuration);

            return configuration;
        }
    }
}