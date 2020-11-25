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
    public class CurtidaController : ControllerBase
    {
        private readonly ICurtidaRepository _curtidaRepository;

        public CurtidaController()
        {
            _curtidaRepository = new CurtidaRepository();
        }


        /// <summary>
        /// Mostra todas as Curtidas cadastradas
        /// </summary>
        /// <returns>Lista com todas as curtidas</returns>

        [HttpGet]
        
        public IActionResult Get()
        {
            try
            {
                var curtidas = _curtidaRepository.Listar();

                if (curtidas.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = curtidas.Count,
                    data = curtidas

                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/curtida/5
        /// <summary>
        /// Mostra uma única curtida
        /// </summary>
        /// <param name="id">Id da curtida</param>
        /// <returns>Uma curtida</returns>
        [HttpGet("{id}")]
        
        public IActionResult Get(Guid id)
        {
            try
            {
                Curtida curtida = _curtidaRepository.BuscarPorId(id);
                if (curtida == null)
                    return NotFound();

                return Ok(curtida);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/curtida
        /// <summary>
        /// Cadastra uma curtida
        /// </summary>
        /// <param name="curtida">Objeto completo de curtida</param>
        /// <returns>curtida cadastrada</returns>
        [HttpPost]
        
        public IActionResult Post(Curtida curtida)
        {
            try
            {

                _curtidaRepository.Adicionar(curtida);

                return Ok(curtida);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }


        // DELETE api/curtida/5
        /// <summary>
        /// Exclui uma curtida
        /// </summary>
        /// <param name="id">Id da curtida</param>
        /// <returns>Id excluido</returns>
        [HttpDelete("{id}")]
       
        public IActionResult Delete(Guid id)
        {
            try
            {
                var curtida = _curtidaRepository.BuscarPorId(id);

                if (curtida == null)
                    return NotFound();

                _curtidaRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
