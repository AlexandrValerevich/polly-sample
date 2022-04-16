using Polly.Retry;
using Polly.Registry;
using Polly.CircuitBreaker;
using Polly.Extensions.Http;

namespace TestPollyFeatures.Infrastructure.DependencyInjection;

public static class PolicyExtensions
{
    public static IServiceCollection AddConfiguredPolicy(this IServiceCollection services)
    {
        AsyncRetryPolicy<HttpResponseMessage> standartHttpWaitAndRetry = HttpPolicyExtensions.HandleTransientHttpError()
            .WaitAndRetryAsync(3, attempt => TimeSpan.FromSeconds(attempt));

        AsyncCircuitBreakerPolicy<HttpResponseMessage> standartCircuitBreaker = HttpPolicyExtensions.HandleTransientHttpError()
            .CircuitBreakerAsync(3, TimeSpan.FromMinutes(1));

        IPolicyRegistry<string> policyRegistry = services.AddPolicyRegistry();
        policyRegistry.Add(nameof(PolicyTypes.StandartHttpWaitAndRetry), standartHttpWaitAndRetry);
        policyRegistry.Add(nameof(PolicyTypes.StandartCircuitBreaker), standartCircuitBreaker);

        return services;
    }
}
