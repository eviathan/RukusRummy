using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using RukusRummy.Api.Hubs;
using RukusRummy.BusinessLogic.Models.DTOs;
using RukusRummy.BusinessLogic.Services;

namespace RukusRummy.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DeckController : ControllerBase
{
    private readonly ILogger<DeckController> _logger;

    private readonly DeckService _deckService;

    private readonly IHubContext<GameHub> _hubContext;


    public DeckController(
        ILogger<DeckController> logger,
        DeckService deckService,
        IHubContext<GameHub> hubContext)
    {
        _logger = logger;
        _deckService = deckService;
        _hubContext = hubContext;
    }

    [HttpPost]  
    public async Task<ActionResult<Guid>> Create(string name, string values)  
    {
        try
        {
            var id = await _deckService.CreateAsync(name, values);
            return Ok(id);
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
