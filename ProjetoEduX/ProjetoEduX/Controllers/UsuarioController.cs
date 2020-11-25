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
    public class usuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public usuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        // GET: api/usuario
        /// <summary>
        /// Mostra todas as instuições cadastradas
        /// </summary>
        /// <returns>Lista com todas as instituições</returns>
        [HttpGet]


        public IActionResult Get()
        {
            try
            {

                var usuarios = _usuarioRepository.Listar();

                if (usuarios.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = usuarios.Count,
                    data = usuarios

                });


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET: api/usuario/5
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
                Usuario usuario = _usuarioRepository.BuscarPorId(id);

                if (usuario == null)
                    return NotFound();

                return Ok(usuario);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/usuario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Altera determinada instituição
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <param name="usuario">Objeto de instituição com alterações</param>
        /// <returns> instituição alterada</returns>
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, Usuario usuario)
        {
            try
            {
                //Edita a usuario
                _usuarioRepository.Editar(usuario);

                //Retorna Ok com os dados da usuario
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/usuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Cadastra uma insituição
        /// </summary>
        /// <param name="usuario">Objeto completo de instituição</param>
        /// <returns>instituição cadastrada</returns>
        [HttpPost]

        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Adicionar(usuario);


                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/usuario/5
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

                var usuario = _usuarioRepository.BuscarPorId(id);


                if (usuario == null)
                    return NotFound();


                _usuarioRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
