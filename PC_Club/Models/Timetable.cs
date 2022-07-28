namespace PC_Club.Models
{
    public class Timetable
    {
        public Guid Id { get; set; }
        public TimeOnly Time { get; set; }

        public List<Club> clubs { get; set; }
        public Timetable()
        {
            clubs = new List<Club>();
        }
    }
}
