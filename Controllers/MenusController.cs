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
    public class MenusController(AppDbContext dbContext) : ControllerBase
    {
        // GET: api/Menus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {
            return await dbContext.Menus.Include(menu => menu.Pages).ToListAsync();
        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            var menu = await dbContext.Menus.FindAsync(id);

            if (menu == null) return NotFound();

            return menu;
        }

        // PUT: api/Menus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu(int id, Menu menu)
        {
            if (id != menu.Id) return BadRequest(); 

            dbContext.Entry(menu).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // POST: api/Menus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Menu>> PostMenu(Menu menu)
        {
            dbContext.Menus.Add(menu);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction("GetMenu", new { id = menu.Id }, menu);
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var menu = await dbContext.Menus.FindAsync(id);
            if (menu == null) return NotFound();

            dbContext.Menus.Remove(menu);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuExists(int id)
        {
            return dbContext.Menus.Any(e => e.Id == id);
        }
    }
}
