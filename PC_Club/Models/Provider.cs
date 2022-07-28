namespace PC_Club.Models
{
    public class Provider
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Speed { get; set; }
        public string Price { get; set; }
        public bool IsStatic { get; set; }

        public string ContractNo { get; set; }

        public int? clubs { get; set; }
        public Club Club { get; set; }
    }
}
