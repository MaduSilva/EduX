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
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;
        public CursoController()
        {
            _cursoRepository = new CursoRepository();
        }

        // GET: api/Curso
        /// <summary>
        /// Mostra todas as instuições cadastradas
        /// </summary>
        /// <returns>Lista com todas as instituições</returns>
        [HttpGet]


        public IActionResult Get()
        {
            try
            {

                var curso = _cursoRepository.Listar();

                if (curso.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = curso.Count,
                    data = curso

                });


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET: api/Curso/5
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
                Curso Curso = _cursoRepository.BuscarPorId(id);

                if (Curso == null)
                    return NotFound();

                return Ok(Curso);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Curso/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Altera determinada instituição
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <param name="Curso">Objeto de instituição com alterações</param>
        /// <returns> instituição alterada</returns>
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, Curso Curso)
        {
            try
            {
                //Edita a Curso
                _cursoRepository.Editar(Curso);

                //Retorna Ok com os dados da Curso
                return Ok(Curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Curso
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Cadastra uma insituição
        /// </summary>
        /// <param name="Curso">Objeto completo de instituição</param>
        /// <returns>instituição cadastrada</returns>
        [HttpPost]

        public IActionResult Post(Curso Curso)
        {
            try
            {
                _cursoRepository.Adicionar(Curso);


                return Ok(Curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Curso/5
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

                var Curso = _cursoRepository.BuscarPorId(id);


                if (Curso == null)
                    return NotFound();


                _cursoRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
