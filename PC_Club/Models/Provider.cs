namespace PC_Club.Models
{
    public class Provider
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long Speed { get; set; }
        public string Price { get; set; }
        public bool IsStatic { get; set; }
        public string ContractNo { get; set; }

        public List<Club> clubs { get; set; }
        public Provider()
        {
            clubs = new List<Club>();
        }
    }
}
