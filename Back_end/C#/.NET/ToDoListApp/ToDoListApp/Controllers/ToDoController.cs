using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Models;
using ToDoListApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ToDoListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ToDoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoTask>>> GetTasks()
        {
            return await _context.ToDoTasks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoTask>> GetTask(int id)
        {
            var task = await _context.ToDoTasks.FindAsync(id);
            if (task == null) return NotFound();
            return task;
        }

        [HttpPost]
        public async Task<ActionResult<ToDoTask>> CreateTask(ToDoTask task)
        {
            _context.ToDoTasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, ToDoTask task)
        {
            if (id != task.Id) return BadRequest();
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.ToDoTasks.FindAsync(id);
            if (task == null) return NotFound();
            _context.ToDoTasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

// Note: The provided code block contains package installation commands for the terminal, not code changes for the file. 
// These commands should be executed in the terminal to install the required packages.
