using System.Text;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using RukusRummy.Api.Hubs;
using RukusRummy.BusinessLogic.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
using RukusRummy.DataAccess.Entities;
using RukusRummy.BusinessLogic.Models.DTOs;
using RukusRummy.BusinessLogic.Models;

namespace RukusRummy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    // private readonly IPlayer _player;
    private readonly ILogger<GameController> _logger;
    private readonly PlayerService _playerService;
    private readonly GameService _gameService; 
    private readonly IHubContext<GameHub> _hubContext;


    public PlayerController(
        // IPlayer player,
        ILogger<GameController> logger,
        PlayerService playerService,
        GameService gameService,
        IHubContext<GameHub> hubContext)
    {
        // _player = player;
        _logger = logger;
        _playerService = playerService;
        _gameService = gameService;
        _hubContext = hubContext;
    }

    // [HttpPost]  
    // [Obsolete]
    // public async Task<ActionResult<Guid>> Add(AddPlayerDTO dto)  
    // {
    //     try
    //     {
    //         var id = await _playerService.AddPlayerToGameAsync(dto);

    //         var claims = new List<Claim>
    //         {
    //             new Claim(ClaimTypes.Name, dto.Name),
    //             new Claim(ClaimTypes.NameIdentifier, id.ToString())
    //         };

    //         var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
    //         var authProperties = new AuthenticationProperties
    //         {
    //             IsPersistent = true,
    //             AllowRefresh = true,

    //         };

    //         await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity));

    //         await _hubContext.Clients.All.SendAsync("UserConnected", dto);
            
    //         var game = await _gameService.GetAsync(dto.GameId);
    //         await _hubContext.Clients.All.SendAsync("GameUpdated", game);

    //         return Ok(id);
    //     }
    //     catch(ArgumentNullException)
    //     {
    //         return BadRequest();
    //     }
    // }

    [HttpPost]  
    public async Task<ActionResult<PlayerDTO>> CreateNewPlayer(CreatePlayerRequestDTO request)  
    {
        try
        {
            var player = await _playerService.CreateAsync(request.Name, request.IsSpectator);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, player.Name),
                new Claim(ClaimTypes.NameIdentifier, player.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                AllowRefresh = true,

            };

            await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity));
            await _hubContext.Clients.All.SendAsync("UserConnected", player);

            return Ok(player);
        }
        catch(ArgumentNullException)
        {
            return BadRequest();
        }
    }

    [HttpPost("deck")]  
    public async Task<ActionResult> AddDeckToPlayer(AddDeckToPlayerRequestDTO request)  
    {
        throw new NotImplementedException();
        // await _playerService.AddDeckAsync(request);

        // if (GameHub.UserConnectionMap.TryGetValue(_player.Id, out var connectionId))
        // {
        //     await _hubContext.Clients.Client(connectionId).SendAsync("PlayerUpdated", _player.Id);
        // }
        
        // return Ok();
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Player>>> GetAllPlayers()
    {
        var players = await _playerService.GetAllPlayersAsync();
        return Ok(players);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlayerDTO>> GetPlayer(Guid id)
    {
        return await _playerService.GetPlayerAsync(id);
    }


    [HttpGet("current-player")]
    public async Task<ActionResult<PlayerDTO>> GetCurrentPlayer()
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
