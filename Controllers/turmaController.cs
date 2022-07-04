using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Escola.Context;
using Escola.Models;

namespace Escola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class turmaController : ControllerBase
    {
        private readonly EscolaContext _context;

        public turmaController(EscolaContext context)
        {
            _context = context;
        }

        // GET: api/turmas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<turma>>> GetTurmas()
        {
          if (_context.turma == null)
          {
              return NotFound();
          }
            return await _context.turma.ToListAsync();
        }

        // GET: api/turmas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<turma>> Getturma(int id)
        {
          if (_context.turma == null)
          {
              return NotFound();
          }
            var turma = await _context.turma.FindAsync(id);

            if (turma == null)
            {
                return NotFound();
            }

            return turma;
        }

        // PUT: api/turmas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putturma(int id, turma turma)
        {
            if (id != turma.Id)
            {
                return BadRequest();
            }

            _context.Entry(turma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!turmaExists(id))
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

        // POST: api/turmas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<turma>> Postturma(turma turma)
        {
          if (_context.turma == null)
          {
              return Problem("Entity set 'EscolaContext.Turmas'  is null.");
          }
            _context.turma.Add(turma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getturma", new { id = turma.Id }, turma);
        }

        // DELETE: api/turmas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteturma(int id)
        {
            if (_context.turma == null)
            {
                return NotFound();
            }
            var turma = await _context.turma.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }

            _context.turma.Remove(turma);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool turmaExists(int id)
        {
            return (_context.turma?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
