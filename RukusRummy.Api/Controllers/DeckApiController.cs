using System.Text;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;
using RukusRummy.Api.Hubs;
using RukusRummy.BusinessLogic.Models.DTOs;
using RukusRummy.BusinessLogic.Services;

namespace RukusRummy.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DeckApiController : ControllerBase
{
    private readonly ILogger<DeckApiController> _logger;

    private readonly DeckService _deckService;

    private readonly IHubContext<GameHub> _hubContext;


    public DeckApiController(
        ILogger<DeckApiController> logger,
        DeckService deckService,
        IHubContext<GameHub> hubContext)
    {
        _logger = logger;
        _deckService = deckService;
        _hubContext = hubContext;
    }

    [HttpGet]  
    public async Task<DeckDTO> Get(Guid id)  
    {
        return await _deckService.GetDeck(id);
    }
    
    [HttpGet]  
    public async Task<IEnumerable<DeckDTO>> GetAll()  
    {
        return await _deckService.GetDecks();
    }
}
