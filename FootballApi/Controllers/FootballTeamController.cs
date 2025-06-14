using FootballApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballTeamController : ControllerBase
    {
        static private List<FootballTeam> teams = new List<FootballTeam>
        {
            new FootballTeam
            {
                Id = 1,
                Name = "Yuko warriors",
                YearFounded = 1945,
                Country = "France",
                Manager = "Mr T"
            },
            new FootballTeam
            {
                Id = 2,
                Name = "Green Lamp United",
                YearFounded = 1890,
                Country = "England",
                Manager = "Mr Q"
            },
            new FootballTeam
            {
                Id = 3,
                Name = "Red Sea United",
                YearFounded = 1956,
                Country = "Brazil",
                Manager = "Mr Z"
            }
        };

        [HttpGet]
        public ActionResult<List<FootballTeam>> GetTeams()
        {
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public ActionResult<FootballTeam> GetTeamByid(int id)
        {
            var team = teams.FirstOrDefault(t => t.Id == id);
            if (team == null)
                return NotFound();
            return Ok(team);
        }

        [HttpPost]
        public ActionResult<FootballTeam> AddTeam(FootballTeam newTeam)
        {
            if (newTeam == null)
                return BadRequest();
            teams.Add(newTeam);
            return CreatedAtAction(nameof(GetTeamByid), new { id = newTeam.Id }, newTeam);
        }

        [HttpPut("{id}")]
        public IActionResult updateTeam(int id, FootballTeam updatedTeam)
        {
            var team = teams.FirstOrDefault(x => x.Id == id);
            if (team == null)
                return NotFound();
            team.Name = updatedTeam.Name;
            team.YearFounded = updatedTeam.YearFounded;
            team.Manager = updatedTeam.Manager;
            team.Country = updatedTeam.Country;

            return Created();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            var team = teams.FirstOrDefault(x => x.Id == id);
            if (team == null)
                return NotFound();
            teams.Remove(team);
            return Ok();
        }
    }
}
