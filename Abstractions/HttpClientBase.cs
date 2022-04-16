// using System.Net;

// namespace TestPollyFeatures.Abstractions;

// public class HttpClientBase
// {
//     private readonly RestClient _client;
//     private readonly AsyncRetryPolicy _policy;

//     public HttpClientBase(HttpClient httpClient, AsyncRetryPolicy policy)
//     {
//         _client = new RestClient(httpClient);
//         _policy = policy;
//     }

//     protected async Task<T> GetAsync<T>(RestRequest request) => await _policy.ExecuteAsync(
//             async (_) => await _client.GetAsync<T>(request),
//             new Context() { { "methodName", nameof(GetAsync) } });

//     protected async Task<T> PostAsync<T>(RestRequest request) => await _policy.ExecuteAsync(
//         async (_) => await _client.PostAsync<T>(request),
//         new Context() { { "methodName", nameof(PostAsync) } }
//     );

//     protected async Task<T> PutAsync<T>(RestRequest request) => await _policy.ExecuteAsync(
//         async (_) => await _client.PutAsync<T>(request),
//         new Context() { { "methodName", nameof(PutAsync) } }
//     );

//     protected async Task<T> DeleteAsync<T>(RestRequest request) => await _policy.ExecuteAsync(
//         async (_) => await _client.DeleteAsync<T>(request),
//         new Context() { { "methodName", nameof(DeleteAsync) } }
//     );

// }
