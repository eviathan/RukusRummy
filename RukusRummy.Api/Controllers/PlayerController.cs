using System.Text;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using RukusRummy.Api.Hubs;
using RukusRummy.BusinessLogic.Services;
using RukusRummy.BusinessLogic.Models.DTOs;

namespace RukusRummy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly ILogger<GameController> _logger;

    private readonly PlayerService _playerService;
    
    private readonly IHubContext<GameHub> _hubContext;


    public PlayerController(
        ILogger<GameController> logger,
        PlayerService playerService,
        IHubContext<GameHub> hubContext)
    {
        _logger = logger;
        _playerService = playerService;
        _hubContext = hubContext;
    }

    [HttpPost]  
    public async Task<ActionResult<Guid>> Add(AddPlayerDTO dto)  
    {
        try
        {
            var id = await _playerService.AddPlayerToGame(dto);
            await _hubContext.Clients.All.SendAsync("UserConnected", dto);
            return Ok(id);
        }
        catch(ArgumentNullException)
        {
            return BadRequest();
        }
    }
}
