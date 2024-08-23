using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hccapiv2.Data;
using hccapiv2.Data.Models;

namespace hccapiv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController(AppDbContext dbContext) : ControllerBase
    {
         // GET: api/Pages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Page>>> GetPages()
        {
            return await dbContext.Pages.ToListAsync();
        }

        // GET: api/Pages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Page>> GetPage(int id)
        {
            var page = await dbContext.Pages.Include(p => p.Menu).FirstOrDefaultAsync(p => p.Id == id);
            return page == null ? NotFound() : page;
        }

        // GET: api/Pages/5/Contents
        [HttpGet("{id}/Contents")]
        public async Task<ActionResult<object>> GetPageContents(int id)
        {
            var contents = await dbContext.Contents
                .Include(c => ((CalendarContent)c).Calendar)
                .Include(c => ((TabContent)c).Tabs)
                .Include(c => ((FileContent)c).Files)
                .Where(c => c.Page != null && c.Page.Id == id)
                .OrderBy(c => c.Index)
                .ToListAsync<object>();

            return contents;
        }

        // PUT: api/Pages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPage(int id, Page page)
        {
            if (id != page.Id) return BadRequest();

            dbContext.Entry(page).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // POST: api/Pages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Page>> PostPage(Page page)
        {
            dbContext.Pages.Add(page);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction("GetPage", new { id = page.Id }, page);
        }

        // DELETE: api/Pages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePage(int id)
        {
            var page = await dbContext.Pages.FindAsync(id);
            if (page == null) return NotFound(); 

            dbContext.Pages.Remove(page);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool PageExists(int id)
        {
            return dbContext.Pages.Any(e => e.Id == id);
        }
    }
}
