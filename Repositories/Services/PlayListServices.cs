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
        public async Task<PlayList> GetPlaylistByIdAsync(int playlistId)
        {
            return await _context.PlayLists
                .Include(p => p.PlaylistSongs)
                .ThenInclude(ps => ps.Song)
                .FirstOrDefaultAsync(p => p.PlayListId == playlistId);
        }

     

        public async Task AddSongToPlaylistAsync(int playlistId, int songId)
        {
            var playlist = await _context.PlayLists.FindAsync(playlistId);
            var song = await _context.Songs.FindAsync(songId);

            if (playlist != null && song != null)
            {
                var playlistSong = new PlaylistSong
                {
                    PlaylistId = playlistId,
                    SongId = songId
                };

                _context.PlaylistSongs.Add(playlistSong);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Song>> GetSongsForPlaylistAsync(int playlistId)
        {
            var playlist = await _context.PlayLists
                .Include(p => p.PlaylistSongs)
                .ThenInclude(ps => ps.Song)
                .FirstOrDefaultAsync(p => p.PlayListId == playlistId);

            return playlist?.PlaylistSongs.Select(ps => ps.Song).ToList();
        }
        public async Task<Song> GetSongByIdAsync(int songId)
        {
            return await _context.Songs.FirstOrDefaultAsync(s => s.SongId == songId);
        }

        public async Task<List<Song>> GetAllSongsAsync()
        {
            return await _context.Songs.ToListAsync();
        }
    }
}
