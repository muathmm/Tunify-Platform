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
    public class PlayListsController : ControllerBase
    {
        private readonly Iplaylist _context;

        public PlayListsController(Iplaylist context)
        {
            _context = context;
        }

        // GET: api/PlayLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayList>>> GetPlayLists()
        {
        
         
            return await _context.GetAllPlaylist();
        }

        // PUT: api/PlayLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayList(int id, PlayList playList)
        {
            if (id != playList.PlayListId)
            {
                return BadRequest();
            }

            _context.UpdatePlaylist(id, playList);

          
            

            return NoContent();
        }

        // POST: api/PlayLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayList>> PostPlayList(PlayList playList)
        {
          if (_context.GetAllPlaylist() == null)
          {
              return Problem("Entity set 'TunifyDbContext.PlayLists'  is null.");
          }
            await _context.CreatePlaylist(playList);

            return CreatedAtAction("GetPlayList", new { id = playList.PlayListId }, playList);
        }

        // DELETE: api/PlayLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayList(int id)
        {
            if (_context.GetAllPlaylist() == null)
            {
                return NotFound();
            }
             await _context.DeletePlaylist(id);
           

           

            return NoContent();
        }


   
        [HttpPost("{playlistId}/songs/{songId}")]
        public async Task<IActionResult> AddSongToPlaylist(int playlistId, int songId)
        {
            var playlist = await _context.GetPlaylistByIdAsync(playlistId);
            var song = await _context.GetSongByIdAsync(songId);

            if (playlist == null || song == null)
            {
                return NotFound();
            }

            await _context.AddSongToPlaylistAsync(playlistId, songId);
            return Ok();
        }

   
        [HttpGet("{playlistId}/songs")]
        public async Task<IActionResult> GetSongsForPlaylist(int playlistId)
        {
            var songs = await _context.GetSongsForPlaylistAsync(playlistId);

            if (songs == null || songs.Count == 0)
            {
                return NotFound();
            }

            return Ok(songs);
        }



    }
}
