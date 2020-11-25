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
    public class rankingController : ControllerBase
    {
        private readonly IRankingRepository _rankingRepository;
        public rankingController()
        {
            _rankingRepository = new RankingRepository();
        }

        // GET: api/ranking
        /// <summary>
        /// Mostra todas as instuições cadastradas
        /// </summary>
        /// <returns>Lista com todas as instituições</returns>
        [HttpGet]


        public IActionResult Get()
        {
            try
            {

                var Ranking = _rankingRepository.Listar();

                if (Ranking.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = Ranking.Count,
                    data = Ranking

                });


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET: api/ranking/5
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
                Ranking ranking = _rankingRepository.BuscarPorId(id);

                if (ranking == null)
                    return NotFound();

                return Ok(ranking);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/ranking/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Altera determinada instituição
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <param name="ranking">Objeto de instituição com alterações</param>
        /// <returns> instituição alterada</returns>
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, Ranking ranking)
        {
            try
            {
                //Edita a ranking
                _rankingRepository.Editar(ranking);

                //Retorna Ok com os dados da ranking
                return Ok(ranking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/ranking
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Cadastra uma insituição
        /// </summary>
        /// <param name="ranking">Objeto completo de instituição</param>
        /// <returns>instituição cadastrada</returns>
        [HttpPost]

        public IActionResult Post(Ranking ranking)
        {
            try
            {
                _rankingRepository.Adicionar(ranking);


                return Ok(ranking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ranking/5
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

                var Ranking = _rankingRepository.BuscarPorId(id);


                if (Ranking == null)
                    return NotFound();


                _rankingRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
