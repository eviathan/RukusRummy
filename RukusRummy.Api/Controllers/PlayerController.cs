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
            var id = await _playerService.AddPlayerToGame(dto);

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
    public async Task<ActionResult<Player>> GetCurrentPlayer()
    {
        if (User != null 
            && User.Identity != null 
            && User.Identity.IsAuthenticated)
        {
            var claims = User.Claims.ToList();
            var userId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if(userId == null)
                return Unauthorized();

            var player = await _playerService.GetPlayer(new Guid(userId));

            // You can return more information based on your application's needs
            return Ok(player);
        }

        return Unauthorized();
    }
}
