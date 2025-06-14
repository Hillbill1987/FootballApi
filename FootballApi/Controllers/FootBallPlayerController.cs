using FootballApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

namespace FootballApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootBallPlayerController : ControllerBase
    {
        static private List<FootballPlayer> players = new List<FootballPlayer>
        {
            new FootballPlayer
            {
                Id = 1,
                Name = "Dave Rogers",
                Team = "Rushie United",
                Nationality = "Scottish",
                Age = 23
            },
            new FootballPlayer
            {
                Id = 2,
                Name = "Jimmy Fred",
                Team = "Astro Rovers",
                Nationality = "French",
                Age = 30
            },
            new FootballPlayer
            {
                Id = 3,
                Name = "Roy Kollow",
                Team = "Red Warriors",
                Nationality = "Danish",
                Age = 27
            }
        };

        [HttpGet]
        public ActionResult<List<FootballPlayer>> Getplayers()
        {
            return Ok(players);
        }

        [HttpGet("{id}")]
        public ActionResult<FootballPlayer> GetPlayerById(int id)
        {
            var player = players.FirstOrDefault(x => x.Id == id);
            if (player == null)
                return NotFound();
            return Ok(player);
        }

        [HttpPost]
        public ActionResult AddPlayer(FootballPlayer newPlayer)
        {
            if (newPlayer == null)
                return BadRequest();
            players.Add(newPlayer);
            return CreatedAtAction(nameof(GetPlayerById), new { id = newPlayer.Id }, newPlayer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlayer(int id, FootballPlayer updatedPlayer)
        {
           var player = players.FirstOrDefault(x => x.Id == id);
           if(player == null)
                return NotFound();

           player.Id = updatedPlayer.Id;
           player.Name = updatedPlayer.Name;
           player.Age = updatedPlayer.Age;
           player.Team = updatedPlayer.Team;
           player.Nationality = updatedPlayer.Nationality;

            return Created();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(int id)
        {
            var player = players.FirstOrDefault(x => x.Id == id);
            if (player == null)
                return NotFound();

            players.Remove(player);
            return Ok();
        }
    }
}
