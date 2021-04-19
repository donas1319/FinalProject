using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTicketReservation.Data;
using MovieTicketReservation.Models;

namespace MovieTicketReservation.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MoviesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movies>>> Getmovies()
        {
            return await _context.movies.ToListAsync();
        }

        // GET: api/MoviesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movies>> GetMovies(int id)
        {
            var movies = await _context.movies.FindAsync(id);

            if (movies == null)
            {
                return NotFound();
            }

            return movies;
        }

        // PUT: api/MoviesApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovies(int id, Movies movies)
        {
            if (id != movies.Id)
            {
                return BadRequest();
            }

            _context.Entry(movies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesExists(id))
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

        // POST: api/MoviesApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Movies>> PostMovies(Movies movies)
        {
            _context.movies.Add(movies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovies", new { id = movies.Id }, movies);
        }

        // DELETE: api/MoviesApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movies>> DeleteMovies(int id)
        {
            var movies = await _context.movies.FindAsync(id);
            if (movies == null)
            {
                return NotFound();
            }

            _context.movies.Remove(movies);
            await _context.SaveChangesAsync();

            return movies;
        }

        private bool MoviesExists(int id)
        {
            return _context.movies.Any(e => e.Id == id);
        }
    }
}
