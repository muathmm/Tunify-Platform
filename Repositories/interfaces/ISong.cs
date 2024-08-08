using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.interfaces
{
    public interface ISong
    {
        Task<Song> CreateSong(Song song);
        Task<List<Song>> GetAllSongs();
        Task<Song> GetSongById(int songId);

        Task<Song> UpdateSong(int id, Song sung);

        Task DeleteSong(int id);
    }
}
