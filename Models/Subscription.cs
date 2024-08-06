namespace Tunify_Platform.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public string SubscriptionType { get; set; }
        public decimal Price { get; set; }
        public User User { get; set; }
    }
}
