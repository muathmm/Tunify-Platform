using Microsoft.AspNetCore.Authentication.Cookies;

namespace Tunify_Platform.Models
{
    public class PlaylistSong
    {
        public int PlaylistId { get; set; }
        public PlayList PlayList { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}
