namespace TestPollyFeatures.Infrastructure.Clients;

public class HttpUserClient : IHttpUserClient
{
    private readonly RestClient _client;

    public HttpUserClient(HttpClient client)
    {
        _client = new RestClient(client);
    }

    public async Task<User> GetUserById(int id)
    {
        var request = new RestRequest("users/{id}");
        request.AddParameter("id", id, ParameterType.UrlSegment);
        User user = await _client.GetAsync<User>(request);

        return user;
    }
}
