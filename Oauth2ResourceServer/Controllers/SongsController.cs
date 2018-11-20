using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Oauth2ResourceServer.Models;

namespace Oauth2ResourceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly Oauth2ResourceServerContext _context;
        private readonly ILogger<SongsController> _logger;
        private readonly IMemoryCache _memCache;


        public SongsController(Oauth2ResourceServerContext context, ILogger<SongsController> logger, IMemoryCache memCache)
        {
            _context = context;
            _logger = logger;
            _memCache = memCache;
        }

        // GET: api/Songs
        [HttpGet]
        public IEnumerable<Song> GetSong([FromQuery]int category_id = 0, [FromQuery]string search = null, [FromQuery]string author = null)
        {
            _logger.LogInformation("Yolo nupakechi.....");
            _logger.LogError("EYolo nupakechi.....");

            var songs = _context.Song;

            if (category_id == 0 && search == null && author == null)
            {
                return _context.Song;
            }

            return _context.Song.Where(q => q.CategoryId == category_id 
                                            || (search != null && (q.Name.Contains(search)                   
                                            || q.Description.Contains(search)                    
                                            || q.Singer.Contains(search) 
                                            || q.Author.Contains(search))) 
                                            || (author != null && q.Author == author));

        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSong([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var song = await _context.Song.FindAsync(id);

            if (song == null)
            {
                return NotFound();
            }

            return Ok(song);
        }

        //Get api/Songs/Category/{Category}
//        [HttpGet("Category/{category}")]
//        [Produces(typeof(Song))]

//        public async Task<IActionResult> GetSongByCategory([FromRoute] Category category)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            var song =  _context.Song.Find();
//
//            if (song == null)
//            {
//                return NotFound();
//            }
//
//            return Ok(song);
//
//        }

        // PUT: api/Songs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong([FromRoute] long id, [FromBody] Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != song.Id)
            {
                return BadRequest();
            }

            _context.Entry(song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Songs
        [EnableCors("MyPolicy")]
        [HttpPost]        

        public async Task<IActionResult> PostSong(Song song)
        {
//            return new JsonResult(song);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Song.Add(song);

            await _context.SaveChangesAsync();

            return new JsonResult(song);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Song.Remove(song);
            await _context.SaveChangesAsync();

            return Ok(song);
        }

        private bool SongExists(long id)
        {
            return _context.Song.Any(e => e.Id == id);
        }
    }
}