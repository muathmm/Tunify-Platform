namespace Tunify_Platform.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public DateTime Join_Date { get; set; }
        public int SubScriprion_ID { get; set; }
        public Subscription Subscription { get; set; }
        public ICollection<PlayList> PlayLists { get; set; }
    }
}
