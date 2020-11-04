using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using ProjetoEduX.Repositories;

namespace ProjetoEduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsletterController : ControllerBase
    {
        private readonly INewsletterRepository _newsletterRepository;

        public NewsletterController()
        {
            _newsletterRepository = new NewsletterRepository();
        }

        // GET: api/Newsletter
        /// <summary>
        /// Mostra todas as Newsletters cadastradas
        /// </summary>
        /// <returns>Lista com todas as newsletters</returns>
        [HttpGet]


        public IActionResult Get()
        {
            try
            {

                var newsletters = _newsletterRepository.Listar();

                if (newsletters.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = newsletters.Count,
                    data = newsletters

                });


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET: api/Newsletter/5
        /// <summary>
        /// Mostra uma única Newsletter
        /// </summary>
        /// <param name="id">Id da Newsletter</param>
        /// <returns>Uma Newsletter</returns>
        [HttpGet("{id}")]

        public IActionResult Get(Guid id)
        {
            try
            {
                Newsletter newsletter = _newsletterRepository.BuscarPorId(id);

                if (newsletter == null)
                    return NotFound();

                return Ok(newsletter);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Newsletter/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Altera determinada Newsletter
        /// </summary>
        /// <param name="id">Id da newsletter</param>
        /// <param name="newsletter">Objeto de Newsletter com alterações</param>
        /// <returns> newsletter alterada</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Newsletter newsletter)
        {
            try
            {
                //Edita a newsletter
                _newsletterRepository.Editar(newsletter);

                //Retorna Ok com os dados da newsletter
                return Ok(newsletter);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Newsletter
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Cadastra uma Newsletter
        /// </summary>
        /// <param name="newsletter">Objeto completo de Newsletter</param>
        /// <returns>newsletter cadastrada</returns>
        [HttpPost]
        public IActionResult Post(Newsletter newsletter)
        {
            try
            {
                _newsletterRepository.Adicionar(newsletter);


                return Ok(newsletter);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Newsletter/5
        /// <summary>
        /// Exclui uma newsletter
        /// </summary>
        /// <param name="id">Id da Newsletter</param>
        /// <returns>Id excluido</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            try
            {

                var newsletter = _newsletterRepository.BuscarPorId(id);


                if (newsletter == null)
                    return NotFound();


                _newsletterRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
