﻿using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class ArtistServices : Iartist
    {

        private readonly TunifyDbContext _context;

        public ArtistServices(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Artist> CreateArtist(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();

            return artist;
        }

        public async Task DeleteArtist(int id)
        {
            var GetArtist = await GetArtistById(id);
          
            _context.Entry(GetArtist).State = EntityState.Deleted;
            //_context.employees.Remove(getEmployee);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Artist>> GetAllArtist()
        {
            var AllArtist = await _context.Artists.ToListAsync();
            return AllArtist;
        }

        public async Task<Artist> GetArtistById(int artistId)
        {

            var artist = await _context.Artists.FindAsync(artistId);
            return artist;
        }

        public async Task<Artist> UpdateArtist(int id, Artist artist)
        {
            var UpArtist = await _context.Artists.FindAsync(id);
            UpArtist = artist;

            await _context.SaveChangesAsync();

            return artist;
        }
    }
}
