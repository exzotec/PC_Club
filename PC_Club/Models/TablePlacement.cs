namespace PC_Club.Models
{
    public class TablePlacement
    {
        public Guid Id { get; set; }
        public string Direction { get; set; }
        public string Entry { get; set; }
        public string Type { get; set; }
        public string AdminPlace { get; set; }

        public int PlacesId { get; set; }
        public Places Places { get; set; }
    }
}
