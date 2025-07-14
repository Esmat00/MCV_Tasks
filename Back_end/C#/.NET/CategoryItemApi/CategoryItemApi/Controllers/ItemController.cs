using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CategoryItemApi.Data;
using CategoryItemApi.Models;

namespace CategoryItemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _context.Items.Include(i => i.Category).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Items.Include(i => i.Category).FirstOrDefaultAsync(i => i.Id == id);
            if (item == null) return NotFound();
            return item;
        }


        [HttpPost]
        public async Task<ActionResult<Item>> CreateItem(ItemDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = new Item
            {
                Title = dto.Title,
                Description = dto.Description,
                CategoryId = dto.CategoryId
            };

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return NotFound();
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
