using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Utils;

namespace ProjetoEduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostagemController : ControllerBase
    {
        private readonly EduXContext _context;

        public PostagemController(EduXContext context)
        {
            _context = context;
        }

        // GET: api/Postagem
        /// <summary>
        /// Mostra todas as Postagems cadastradas
        /// </summary>
        /// <returns>Lista com todas as Postagems</returns>
        [HttpGet]
       
        public async Task<ActionResult<IEnumerable<Postagem>>> GetPostagem()
        {
            return await _context.Postagem.ToListAsync();
        }

        // GET: api/Postagem/5
        /// <summary>
        /// Mostra uma única Postagem
        /// </summary>
        /// <param name="id">Id da Postagem</param>
        /// <returns>Uma Postagem</returns>
        [HttpGet("{id}")]
        
        public async Task<ActionResult<Postagem>> GetPostagem(Guid id)
        {
            var Postagem = await _context.Postagem.FindAsync(id);

            if (Postagem == null)
            {
                return NotFound();
            }

            return Postagem;
        }

        // PUT: api/Postagem/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        /// <summary>
        /// Altera determinada Postagem
        /// </summary>
        /// <param name="id">Id da Postagem</param>
        /// <param name="Postagem">Objeto de Postagem com alterações</param>
        /// <returns> Postagem alterada</returns>
        [HttpPut("{id}")]
    
        public async Task<IActionResult> PutPostagem(Guid id, Postagem Postagem)
        {
            if (id != Postagem.IdPostagem)
            {
                return BadRequest();
            }

            _context.Entry(Postagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostagemExists(id))
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

        // POST: api/Postagem
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        /// <summary>
        /// Cadastra uma Postagem
        /// </summary>
        /// <param name="Postagem">Objeto completo de Postagem</param>
        /// <returns>Postagem cadastrada</returns>
        [HttpPost]
      
        public async Task<ActionResult<Postagem>> PostPostagem([FromForm] Postagem Postagem)
        {
            try
            {

                if (Postagem.Imagem != null)
                {
                    var urlImagem = Upload.Local(Postagem.Imagem);

                    Postagem.UrlImagem = urlImagem;
                }

                _context.Postagem.Add(Postagem);
                await _context.SaveChangesAsync();

                return Ok(Postagem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/Postagem/5

        /// <summary>
        /// Exclui uma Postagem
        /// </summary>
        /// <param name="id">Id da Postagem</param>
        /// <returns>Id excluido</returns>
        [HttpDelete("{id}")]
       
        public async Task<ActionResult<Postagem>> DeletePostagem(Guid id)
        {
            var Postagem = await _context.Postagem.FindAsync(id);
            if (Postagem == null)
            {
                return NotFound();
            }

            _context.Postagem.Remove(Postagem);
            await _context.SaveChangesAsync();

            return Postagem;
        }

        private bool PostagemExists(Guid id)
        {
            return _context.Postagem.Any(e => e.IdPostagem == id);
        }
    }
}
