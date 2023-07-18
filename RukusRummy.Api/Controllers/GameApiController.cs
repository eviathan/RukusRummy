using System.Text;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;
using RukusRummy.Api.Hubs;
using RukusRummy.BusinessLogic.Services;

namespace RukusRummy.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GameApiController : ControllerBase
{
    private readonly ILogger<GameApiController> _logger;

    private readonly GameService _gameService;
    
    private readonly IGameExportService _gameExportService;

    private readonly IHubContext<GameHub> _hubContext;


    public GameApiController(
        ILogger<GameApiController> logger,
        GameService gameService,
        IGameExportService gameExportService,
        IHubContext<GameHub> hubContext)
    {
        _logger = logger;
        _gameService = gameService;
        _gameExportService = gameExportService;
        _hubContext = hubContext;
    }

    [HttpGet]
    public async Task RevealHand(Guid gameId)
    {
        await _hubContext.Clients.All.RevealCards();
    }

    [HttpGet]  
    public async Task<IActionResult> DownloadExport(Guid gameId)  
    {  
        var game = await _gameService.GetGameAsync(gameId);
    
        if (game != null)  
        {  
            var dataString = _gameExportService.Serialise(game);
            return new FileContentResult(Encoding.UTF8.GetBytes(dataString), "application/csv")
            {
                FileDownloadName = $"{game.Name}.csv"
            };  
        }  

        return NotFound();  
    }
}
