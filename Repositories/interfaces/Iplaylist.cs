using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.interfaces
{
    public interface Iplaylist
    {
        Task<PlayList> CreatePlaylist(PlayList PlayList);
        Task<List<PlayList>> GetAllPlaylist();
        Task<PlayList> GetPlaylistById(int PlayListId);

        Task<PlayList> UpdatePlaylist(int id, PlayList PlayList);

        Task DeletePlaylist(int id);
    }
}
