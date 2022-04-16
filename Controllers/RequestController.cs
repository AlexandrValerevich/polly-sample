using Microsoft.AspNetCore.Mvc;


namespace TestPollyFeatures.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    private readonly IHttpUserClient _client;
    public RequestController(IHttpUserClient client)
    {
        _client = client;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        User user = await _client.GetUserById(id);
        return Ok(user);
    }
}
