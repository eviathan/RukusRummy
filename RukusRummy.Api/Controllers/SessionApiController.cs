using Microsoft.AspNetCore.Mvc;

namespace RukusRummy.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionApiController : ControllerBase
{
    private readonly ILogger<SessionApiController> _logger;

    public SessionApiController(ILogger<SessionApiController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public void Get()
    {
    }
}
