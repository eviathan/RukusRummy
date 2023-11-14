using System.Text;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using RukusRummy.Api.Hubs;
using RukusRummy.BusinessLogic.Services;
using RukusRummy.BusinessLogic.Models.DTOs;

namespace RukusRummy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly ILogger<GameController> _logger;

    private readonly GameService _gameService;
    
    private readonly IHubContext<GameHub> _hubContext;


    public GameController(
        ILogger<GameController> logger,
        GameService gameService,
        IHubContext<GameHub> hubContext)
    {
        _logger = logger;
        _gameService = gameService;
        _hubContext = hubContext;
    }

    [HttpPost]  
    public async Task<ActionResult<Guid>> Create(CreateGameDTO dto)  
    {
        try
        {
            var id = await _gameService.CreateAsync(dto);
            return Ok(id);
        }
        catch(ArgumentNullException)
        {
            return BadRequest();
        }
    }

    [HttpGet("{id}")]  
    public async Task<GameDTO> Get(Guid id)  
    {
        return await _gameService.GetAsync(id);
    }
    
    [HttpGet]  
    public async Task<IEnumerable<GameDTO>> GetAll()  
    {
        return await _gameService.GetAllAsync();
    }

    [HttpPut]  
    public async Task<ActionResult> Update(GameDTO dto)  
    {
        try
        {
            await _gameService.UpdateAsync(dto);
            return Ok();
        }
        catch(Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete]  
    public async Task<ActionResult> Delete(Guid id)  
    {
        try
        {
            await _gameService.DeleteAsync(id);
            return Ok();
        }
        catch (ArgumentOutOfRangeException)
        {
            return NotFound();
        }
    }

    [HttpPost("revealhand/{id}")]
    public async Task RevealHand(Guid id)
    {
        await _hubContext.Clients.All.SendAsync("RevealCards");
    }

    [HttpGet("startnewround/{gameId}")]
    public async Task StartNewRound(Guid gameId)
    {
        await _gameService.StartNewRoundAsync(gameId);
        await _hubContext.Clients.All.SendAsync("GameUpdated");
    }

    [HttpGet("export/{id}")]  
    public async Task<IActionResult> DownloadExport(Guid id)  
    {  
        var game = await _gameService.GetAsync(id);
    
        if (game != null)  
        {  
            var dataString = ""; // TODO: NEED TO SERIALISE THE DTO
            return new FileContentResult(Encoding.UTF8.GetBytes(dataString), "application/csv")
            {
                FileDownloadName = $"{game.Name}.csv"
            };  
        }  

        return NotFound();  
    }
}
