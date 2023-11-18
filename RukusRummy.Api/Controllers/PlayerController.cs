using System.Text;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using RukusRummy.Api.Hubs;
using RukusRummy.BusinessLogic.Services;
using RukusRummy.BusinessLogic.Models.DTOs;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using RukusRummy.BusinessLogic.Models;
using System.ComponentModel.DataAnnotations;

namespace RukusRummy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly ILogger<GameController> _logger;
    private readonly PlayerService _playerService;
    private readonly GameService _gameService; 
    private readonly IHubContext<GameHub> _hubContext;


    public PlayerController(
        ILogger<GameController> logger,
        PlayerService playerService,
        GameService gameService,
        IHubContext<GameHub> hubContext)
    {
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

    public class CreateNewPlayerRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public bool IsSpectator { get; set; }
    }

    [HttpPost]  
    public async Task<ActionResult<Guid>> CreateNewPlayer(CreateNewPlayerRequest request)  
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


    
//   async addPlayerToGame(playerId: string, gameId: string): Promise<IPlayer> {
//     return await this.getAsync(undefined, `${playerId}/game/${gameId}`);
//   }
    // TODO: Maybe move this to the game controller
    [HttpPost("{playerId}/game/{gameId}")]  
    public async Task<ActionResult<Guid>> AddPlayerToGame(Guid playerId, Guid gameId)  
    {
        try
        {
            var game = await _gameService.GetAsync(gameId);

            if(!game.Players.Any(x => x.Id == playerId))
            {
                var player = await _playerService.GetPlayerAsync(playerId);
                game.Players.Add(player);
                await _gameService.UpdateAsync(game);
            }
            
            await _hubContext.Clients.All.SendAsync("GameUpdated", gameId);

            return Ok(gameId);
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
