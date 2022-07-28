namespace PC_Club.Models
{
    public class Periphery
    {
        public Guid Id { get; set; }
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string Monitor { get; set; }
        public string Keyboard { get; set; }
        public string Mouse { get; set; }
        public string Seat { get; set; }

        public List<Places> Places { get; set; }
        public Periphery()
        {
            Places = new List<Places>();
        }
    }
}
