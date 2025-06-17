using FootballApi.Data;
using FootballApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;

namespace FootballApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootBallPlayerController : ControllerBase
    {
        //static private List<FootballPlayer> players = new List<FootballPlayer>
        //{
        //    new FootballPlayer
        //    {
        //        Id = 1,
        //        Name = "Dave Rogers",
        //        Team = "Rushie United",
        //        Nationality = "Scottish",
        //        Age = 23
        //    },
        //    new FootballPlayer
        //    {
        //        Id = 2,
        //        Name = "Jimmy Fred",
        //        Team = "Astro Rovers",
        //        Nationality = "French",
        //        Age = 30
        //    },
        //    new FootballPlayer
        //    {
        //        Id = 3,
        //        Name = "Roy Kollow",
        //        Team = "Red Warriors",
        //        Nationality = "Danish",
        //        Age = 27
        //    }
        //};
        private readonly DataContext _dataContext;
        public FootBallPlayerController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FootballPlayer>>> Getplayers()
        {
            return Ok(await _dataContext.players.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FootballPlayer>> GetPlayerById(int id)
        {
            var player = await _dataContext.players.FindAsync(id);
            if (player == null)
                return NotFound();
            return Ok(player);
        }

        [HttpPost]
        public async Task<ActionResult<FootballPlayer>> AddPlayer(FootballPlayer newPlayer)
        {
            if (newPlayer == null)
                return BadRequest();
            _dataContext.players.Add(newPlayer);
            await _dataContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPlayerById), new { id = newPlayer.Id }, newPlayer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(int id, FootballPlayer updatedPlayer)
        {
            var player = await _dataContext.players.FindAsync(id);
            if (player == null)
                return NotFound();

            player.Id = updatedPlayer.Id;
            player.Name = updatedPlayer.Name;
            player.Age = updatedPlayer.Age;
            player.Team = updatedPlayer.Team;
            player.Nationality = updatedPlayer.Nationality;

            await _dataContext.SaveChangesAsync();

            return Created();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _dataContext.players.FindAsync(id);
            if (player == null)
                return NotFound();

            _dataContext.players.Remove(player);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }
    }
}
