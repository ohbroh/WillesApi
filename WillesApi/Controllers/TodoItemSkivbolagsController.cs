using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace WillesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemSkivbolagsController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoItemSkivbolagsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/TodoItemSkivbolags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemSkivbolag>>> GetSkivbolag()
        {
            return await _context.Skivbolag.ToListAsync();
        }

        // GET: api/TodoItemSkivbolags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemSkivbolag>> GetTodoItemSkivbolag(int id)
        {
            var todoItemSkivbolag = await _context.Skivbolag.FindAsync(id);

            if (todoItemSkivbolag == null)
            {
                return NotFound();
            }

            return todoItemSkivbolag;
        }

        // PUT: api/TodoItemSkivbolags/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItemSkivbolag(int id, TodoItemSkivbolag todoItemSkivbolag)
        {
            if (id != todoItemSkivbolag.Skivbolag_ID)
            {
                return BadRequest();
            }

            _context.Entry(todoItemSkivbolag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemSkivbolagExists(id))
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

        // POST: api/TodoItemSkivbolags
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TodoItemSkivbolag>> PostTodoItemSkivbolag(TodoItemSkivbolag todoItemSkivbolag)
        {
            _context.Skivbolag.Add(todoItemSkivbolag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItemSkivbolag", new { id = todoItemSkivbolag.Skivbolag_ID }, todoItemSkivbolag);
        }

        // DELETE: api/TodoItemSkivbolags/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItemSkivbolag>> DeleteTodoItemSkivbolag(int id)
        {
            var todoItemSkivbolag = await _context.Skivbolag.FindAsync(id);
            if (todoItemSkivbolag == null)
            {
                return NotFound();
            }

            _context.Skivbolag.Remove(todoItemSkivbolag);
            await _context.SaveChangesAsync();

            return todoItemSkivbolag;
        }

        private bool TodoItemSkivbolagExists(int id)
        {
            return _context.Skivbolag.Any(e => e.Skivbolag_ID == id);
        }
    }
}
