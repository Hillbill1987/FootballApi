namespace FootballApi.Models
{
    public class UpdatedFootballTeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearFounded { get; set; }
        public string Country { get; set; }
        public string Manager { get; set; }
    }
}
