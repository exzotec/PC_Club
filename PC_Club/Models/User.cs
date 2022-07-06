namespace PC_Club.Models
{
    public class User
    {
        public Guid userId { get; set; }
        public string first_name { get; set; }
        public string? middle_name { get; set; }
        public string last_name { get; set; }
        public string login { get; set; }
        private string password { get; set; }
        public string e_mail { get; set; }
        public string phone_number { get; set; }
        public DateTime birthday { get; set; }

        public Role roleId { get; set; }
    }
}
