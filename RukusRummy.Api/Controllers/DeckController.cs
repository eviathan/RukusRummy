using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using RukusRummy.Api.Hubs;
using RukusRummy.BusinessLogic.Models.DTOs;
using RukusRummy.BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using RukusRummy.BusinessLogic.Models;

namespace RukusRummy.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DeckController : ControllerBase
{
    private readonly IPlayer _player;
    private readonly ILogger<DeckController> _logger;
    private readonly DeckService _deckService;
    private readonly IHubContext<GameHub> _hubContext;

    public DeckController(
        IPlayer player,
        ILogger<DeckController> logger,
        DeckService deckService,
        IHubContext<GameHub> hubContext)
    {
        _player = player;
        _logger = logger;
        _deckService = deckService;
        _hubContext = hubContext;
    }

    [HttpPost]  
    public async Task<ActionResult<DeckDTO>> Create(CreateDeckRequestDTO request)  
    {
        try
        {
            var deck = await _deckService.CreateAsync(request);
            await _hubContext.Clients.All.SendAsync("PlayerUpdated", _player.Id.ToString());
            return Ok(deck);
        }
        catch(ArgumentNullException)
        {
            return BadRequest();
        }
    }

    [HttpGet("{id}")]  
    public async Task<ActionResult<DeckDTO>> Get(Guid id)  
    {
        try
        {
            var deck = await _deckService.GetAsync(id);
            return Ok(deck);
        }
        catch(ArgumentOutOfRangeException)
        {
            return NotFound();
        }
    }
    
    [HttpGet]  
    public async Task<IEnumerable<DeckDTO>> GetAll()  
    {
        return await _deckService.GetAllAsync();
    }

    [HttpPut]  
    public async Task<ActionResult> Update(DeckDTO dto)  
    {
        try
        {
            await _deckService.UpdateAsync(dto);
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
            await _deckService.DeleteAsync(id);
            return Ok();
        }
        catch (ArgumentOutOfRangeException)
        {
            return NotFound();
        }
    }
}
