using System.Text;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using RukusRummy.Api.Hubs;
using RukusRummy.BusinessLogic.Services;
using RukusRummy.BusinessLogic.Models.DTOs;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using RukusRummy.BusinessLogic.Models;

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
            var id = await _playerService.AddPlayerToGameAsync(dto);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, dto.Name),
                new Claim(ClaimTypes.NameIdentifier, id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                AllowRefresh = true,

            };

            await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity));

            await _hubContext.Clients.All.SendAsync("UserConnected", dto);
            
            return Ok(id);
        }
        catch(ArgumentNullException)
        {
            return BadRequest();
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Player>>> GetAllPlayers()
    {
        var players = await _playerService.GetAllPlayersAsync();
        return Ok(players);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Player>> GetPlayer(Guid id)
    {
        return await _playerService.GetPlayerAsync(id);
    }


    [HttpGet("current-player")]
    public async Task<ActionResult<Player>> GetCurrentPlayer()
    {
        if (User != null 
            && User.Identity != null 
            && User.Identity.IsAuthenticated)
        {
            try
            {
                var claims = User.Claims.ToList();
                var userId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                
                var player = await _playerService.GetPlayerAsync(new Guid(userId));

                // You can return more information based on your application's needs
                return Ok(player);
            }
            catch(Exception)
            {
                return Unauthorized();
            }
        }

        return Unauthorized();
    }
}
