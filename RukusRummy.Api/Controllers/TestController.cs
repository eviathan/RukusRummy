using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using RukusRummy.Api.Hubs;
using RukusRummy.BusinessLogic.Models.DTOs;
using RukusRummy.BusinessLogic.Services;

namespace RukusRummy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(
        ILogger<TestController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]  
    public async Task<string> Get()  
    {
        return await Task.FromResult("WORKING: This is coming from the test endpoint!");
    }
}
