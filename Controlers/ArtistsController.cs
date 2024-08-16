using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly Iartist _context;

        public ArtistsController(Iartist context)
        {
            _context = context;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {

            return await _context.GetAllArtist();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            if (_context.GetAllArtist() == null)
            {
                return NotFound();
            }
            var artist = await _context.GetArtistById(id);

            if (artist == null)
            {
                return NotFound();
            }

            return artist;
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
            if (id != artist.ArtistId)
            {
                return BadRequest();
            }

            await _context.UpdateArtist(id, artist);





            return NoContent();
        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            if (_context.GetAllArtist() == null)
            {
                return Problem("Entity set 'TunifyDbContext.Artists'  is null.");
            }
            _context.CreateArtist(artist);


            return CreatedAtAction("GetArtist", new { id = artist.ArtistId }, artist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            if (_context.GetAllArtist() == null)
            {
                return NotFound();
            }
            await _context.DeleteArtist(id);




            return NoContent();
        }

        [HttpPost("{artistId}/songs/{songId}")]
        public async Task<IActionResult> AddSongToArtist(int artistId, int songId)
        {
            try
            {
                await _context.AddSongToArtist(artistId, songId);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/artists/{artistId}/songs
        [HttpGet("{artistId}/songs")]
        public async Task<IActionResult> GetSongsByArtist(int artistId)
        {
            try
            {
                var songs = await _context.GetSongsByArtist(artistId);
                return Ok(songs);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }


        }
    }
}
