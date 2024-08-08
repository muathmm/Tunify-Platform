using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class PlayListServices : Iplaylist
    {

        private readonly TunifyDbContext _context;

        public PlayListServices(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<PlayList> CreatePlaylist(PlayList PlayList)
        {
            _context.PlayLists.Add(PlayList);
            await _context.SaveChangesAsync();

            return PlayList;
        }

        public async Task DeletePlaylist(int id)
        {
            var getPlaylist = await GetPlaylistById(id);
            _context.Entry(getPlaylist).State = EntityState.Deleted;
            //_context.employees.Remove(getEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PlayList>> GetAllPlaylist()
        {
            var Allplaylist = await _context.PlayLists.ToListAsync();
            return Allplaylist;
        }

        public async Task<PlayList> GetPlaylistById(int PlayListId)
        {

            var Playlist = await _context.PlayLists.FindAsync(PlayListId);
            return Playlist;
        }

        public async Task<PlayList> UpdatePlaylist(int id, PlayList PlayList)
        {
            var UpPlaylist = await _context.PlayLists.FindAsync(id);
            UpPlaylist = PlayList;

            await _context.SaveChangesAsync();

            return PlayList;
        }
    }
}
