using FootballApi.Data;
using FootballApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FootballApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballTeamController : ControllerBase
    {
        //static private List<FootballTeam> teams = new List<FootballTeam>
        //{
        //    new FootballTeam
        //    {
        //        Id = 1,
        //        Name = "Yuko warriors",
        //        YearFounded = 1945,
        //        Country = "France",
        //        Manager = "Mr T"
        //    },
        //    new FootballTeam
        //    {
        //        Id = 2,
        //        Name = "Green Lamp United",
        //        YearFounded = 1890,
        //        Country = "England",
        //        Manager = "Mr Q"
        //    },
        //    new FootballTeam
        //    {
        //        Id = 3,
        //        Name = "Red Sea United",
        //        YearFounded = 1956,
        //        Country = "Brazil",
        //        Manager = "Mr Z"
        //    }
        //};

        private readonly DataContext _dataContext;
        public FootballTeamController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FootballTeam>>> GetTeams()
        {
            return Ok(await _dataContext.teams.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FootballTeam>> GetTeamByid(int id)
        {
            var team = await _dataContext.teams.FindAsync(id);
            if (team == null)
                return NotFound();
            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult<FootballTeam>> AddTeam(FootballTeam newTeam)
        {
            if (newTeam == null)
                return BadRequest();
            _dataContext.teams.Add(newTeam);
            await _dataContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTeamByid), new { id = newTeam.Id }, newTeam);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateTeam(int id, FootballTeam updatedTeam)
        {
            var team = await _dataContext.teams.FindAsync(id);
            if (team == null)
                return NotFound();
            team.Name = updatedTeam.Name;
            team.YearFounded = updatedTeam.YearFounded;
            team.Manager = updatedTeam.Manager;
            team.Country = updatedTeam.Country;

            await _dataContext.SaveChangesAsync();

            return Created();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _dataContext.teams.FindAsync(id);
            if (team == null)
                return NotFound();
            _dataContext.teams.Remove(team);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }
    }
}
