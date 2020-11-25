using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoEdux.Repositories;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using ProjetoEduX.Repositories;
using ProjetoEduX.Utils;

namespace ProjetoEduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class dicaController : ControllerBase
    {
        private readonly IDicaRepository _dicaRepository;
        public dicaController()
        {
            _dicaRepository = new DicaRepository();
        }

        // GET: api/dica
        /// <summary>
        /// Mostra todas as instuições cadastradas
        /// </summary>
        /// <returns>Lista com todas as instituições</returns>
        [HttpGet]


        public IActionResult Get()
        {
            try
            {

                var Dica = _dicaRepository.Listar();

                if (Dica.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = Dica.Count,
                    data = Dica

                });


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET: api/dica/5
        /// <summary>
        /// Mostra uma única instituição
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <returns>Uma instituição</returns>
        [HttpGet("{id}")]

        public IActionResult Get(Guid id)
        {
            try
            {
                Dica dica = _dicaRepository.BuscarPorId(id);

                if (dica == null)
                    return NotFound();

                return Ok(dica);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/dica/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Altera determinada instituição
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <param name="dica">Objeto de instituição com alterações</param>
        /// <returns> instituição alterada</returns>
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, Dica dica)
        {
            try
            {
                //Edita a dica
                _dicaRepository.Editar(dica);

                //Retorna Ok com os dados da dica
                return Ok(dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/dica
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Cadastra uma insituição
        /// </summary>
        /// <param name="dica">Objeto completo de instituição</param>
        /// <returns>instituição cadastrada</returns>
        [HttpPost]

        public IActionResult Post(Dica dica)
        {
            try
            {
                if (dica.Imagem != null)
                {
                 
                }

                _dicaRepository.Adicionar(dica);


                return Ok(dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/dica/5
        /// <summary>
        /// Exclui uma instituição
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <returns>Id excluido</returns>
        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {

                var Dica = _dicaRepository.BuscarPorId(id);


                if (Dica == null)
                    return NotFound();


                _dicaRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
