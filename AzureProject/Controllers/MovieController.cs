using AzureProject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase

    {
        private readonly ShowContext _context;
        public MovieController(ShowContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> Get()
        {
            List<Movie> movies=  await _context.Movies.ToListAsync();
            return Ok(movies);
        }
        [HttpPost]
        public async Task<ActionResult<Movie>> Post(Movie movie)
        {
            try
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest("Exception..." + e.Message);
            }
            return Ok(movie);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var mov = await _context.Movies.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (mov != null)
            {
                _context.Remove(mov);
                await _context.SaveChangesAsync();
                return Ok(mov);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(Movie movie)
        {
            try
            {
                _context.Update(movie);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest("Exception..." + e.Message);
            }
            return Ok(movie);
        }
    }
}
