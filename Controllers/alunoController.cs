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
    public class alunoController : ControllerBase
    {
        private readonly EscolaContext _context;

        public alunoController(EscolaContext context)
        {
            _context = context;
        }

        // GET: api/alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<aluno>>> GetAlunos()
        {
          if (_context.aluno == null)
          {
              return NotFound();
          }
            return await _context.aluno.ToListAsync();
        }

        // GET: api/alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<aluno>> Getaluno(int id)
        {
          if (_context.aluno == null)
          {
              return NotFound();
          }
            var aluno = await _context.aluno.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        // PUT: api/alunos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putaluno(int id, aluno aluno)
        {
            if (id != aluno.Id)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!alunoExists(id))
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

        // POST: api/alunos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<aluno>> Postaluno(aluno aluno)
        {
          if (_context.aluno == null)
          {
              return Problem("Entity set 'EscolaContext.Alunos'  is null.");
          }
            _context.aluno.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getaluno", new { id = aluno.Id }, aluno);
        }

        // DELETE: api/alunos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletealuno(int id)
        {
            if (_context.aluno == null)
            {
                return NotFound();
            }
            var aluno = await _context.aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.aluno.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool alunoExists(int id)
        {
            return (_context.aluno?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
