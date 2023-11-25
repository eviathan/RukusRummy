using System.Text;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using RukusRummy.Api.Hubs;
using RukusRummy.BusinessLogic.Services;
using RukusRummy.BusinessLogic.Models.DTOs;
using RukusRummy.DataAccess.Entities;

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

    public class CreateGameRequest
    {
        public Guid PlayerId { get; set; }
        public string? Name { get; set; }
        public Guid Deck { get; set; }
        public bool AutoReveal { get; set; }
        public bool EnableFunFeatures { get; set; }
        public bool ShowAverage { get; set; }
        public bool AutoCloseSession { get; set; }
        public PlayerPermissionType RevealCardsPermission { get; set; }
        public PlayerPermissionType ManageIssuesPermission { get; set; }
    }

    [HttpPost]  
    public async Task<ActionResult<Guid>> Create(CreateGameRequest request)  
    {
        try
        {
            var id = await _gameService.CreateAsync(new CreateGameDTO
            {
                Name = request.Name,
                PlayerId = request.PlayerId,
                Deck = request.Deck,
                AutoCloseSession = request.AutoCloseSession,
                AutoReveal = request.AutoReveal,
                EnableFunFeatures = request.EnableFunFeatures,
                ManageIssuesPermission = request.ManageIssuesPermission,
                RevealCardsPermission = request.RevealCardsPermission,
                ShowAverage = request.ShowAverage,
            });
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

    [HttpPost("revealcards/{id}")]
    public async Task RevealCards(Guid id)
    {
        await _hubContext.Clients.Group(id.ToString()).SendAsync("RevealCards");
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
