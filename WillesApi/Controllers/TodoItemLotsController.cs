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
    public class TodoItemLotsController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoItemLotsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/TodoItemLots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemLot>>> GetLot()
        {
            return await _context.Lot.ToListAsync();
        }

        // GET: api/TodoItemLots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemLot>> GetTodoItemLot(int id)
        {
            var todoItemLot = await _context.Lot.FindAsync(id);

            if (todoItemLot == null)
            {
                return NotFound();
            }

            return todoItemLot;
        }

        // PUT: api/TodoItemLots/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItemLot(int id, TodoItemLot todoItemLot)
        {
            if (id != todoItemLot.Lot_ID)
            {
                return BadRequest();
            }

            _context.Entry(todoItemLot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemLotExists(id))
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

        // POST: api/TodoItemLots
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TodoItemLot>> PostTodoItemLot(TodoItemLot todoItemLot)
        {
            _context.Lot.Add(todoItemLot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItemLot", new { id = todoItemLot.Lot_ID }, todoItemLot);
        }

        // DELETE: api/TodoItemLots/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItemLot>> DeleteTodoItemLot(int id)
        {
            var todoItemLot = await _context.Lot.FindAsync(id);
            if (todoItemLot == null)
            {
                return NotFound();
            }

            _context.Lot.Remove(todoItemLot);
            await _context.SaveChangesAsync();

            return todoItemLot;
        }

        private bool TodoItemLotExists(int id)
        {
            return _context.Lot.Any(e => e.Lot_ID == id);
        }
    }
}
