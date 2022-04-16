
using TestPollyFeatures.Infrastructure.Clients;

namespace TestPollyFeatures.Infrastructure.DependencyInjection;

public static class HttpClientExtensions
{
    public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration config)
    {
        services.AddHttpClient<IHttpUserClient, HttpUserClient>(client =>
        {
            client.BaseAddress = new Uri(config.GetValue<string>("UserService:BaseUrl"));
        })
        .AddPolicyHandlerFromRegistry(nameof(PolicyTypes.StandartHttpWaitAndRetry))
        .AddPolicyHandlerFromRegistry(nameof(PolicyTypes.StandartCircuitBreaker));
        
        return services;
    }
}
