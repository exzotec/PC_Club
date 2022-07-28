namespace PC_Club.Models
{
    public class Club
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; } 

        public Provider Provider { get; set; }

        public Timetable Timetable { get; set; }
    }
}
