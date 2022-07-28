using static System.Net.Mime.MediaTypeNames;

namespace PC_Club.Models
{
    public class Room
    {
        public bool IsRented { get; set; }
        public bool IsOwn { get; set; }
        public string ContractNo { get; set; }
        public string DigitizedDocumentName { get; set; }

        public List<Club> Clubs { get; set; }
        public Room ()
        {
            Clubs = new List<Club>();
        }
    }
}
