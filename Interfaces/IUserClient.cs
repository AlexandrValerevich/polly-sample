namespace TestPollyFeatures.Interfaces;

public interface IHttpUserClient
{
    Task<User> GetUserById(int id);
}
