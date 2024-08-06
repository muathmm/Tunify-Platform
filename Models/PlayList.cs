namespace Tunify_Platform.Models
{
    public class PlayList

    {
        public int PlayListId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string PlayListName { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; }

    }
}
