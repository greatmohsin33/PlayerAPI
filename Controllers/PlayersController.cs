using Microsoft.AspNetCore.Mvc;
using PlayerAPI.Data;
using PlayerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PlayerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly AppDbContext _context;

    public PlayersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> SavePlayer([FromBody] Player player)
    {
        var existing = await _context.Players.FindAsync(player.Id);
        if (existing == null)
            _context.Players.Add(player);
        else
            existing.Name = player.Name;

        await _context.SaveChangesAsync();
        return Ok(player);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlayer(int id)
    {
        var player = await _context.Players.FindAsync(id);
        if (player == null)
            return NotFound();
        return Ok(player);
    }
}
