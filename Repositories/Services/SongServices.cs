using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class SongServices : ISong
    {
        private readonly TunifyDbContext _context;

        public SongServices(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Song> CreateSong(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return song;
        }

        public async Task DeleteSong(int id)
        {
            var getSong= await GetSongById(id);
            _context.Entry(getSong).State = EntityState.Deleted;
            //_context.employees.Remove(getEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Song>> GetAllSongs()
        {
            var AllSongs = await _context.Songs.ToListAsync();
            return AllSongs;
        }

        public async Task<Song> GetSongById(int songId)
        {
            var Song = await _context.Songs.FindAsync(songId);
            return Song;
        }

        public async Task<Song> UpdateSong(int id, Song sung)
        {
            var UpSong = await _context.Songs.FindAsync(id);
            UpSong = sung;

            await _context.SaveChangesAsync();

            return UpSong;

        }
    }
}
