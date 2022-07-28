namespace PC_Club.Models
{
    public class Places
    {
        public Guid Id { get; set; }
        public int Count { get; set; }
        public int VIPCount { get; set; }
        public int AvailableCount { get; set; }

        public TablePlacement TablePlacement { get; set; }

        public Periphery Periphery { get; set; }
    }
}
