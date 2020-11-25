using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private EduXContext _ctx;
        public UsuarioRepository()
        {
            _ctx = new EduXContext();
        }

        /// <summary>
        /// Cria uma usuario
        /// </summary>
        /// <param name="usuario">usuario a ser criada</param>
        public void Adicionar(Usuario usuario)
        {
            try
            {

                _ctx.Usuario.Add(usuario);


                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca uma usuario pelo Id
        /// </summary>
        /// <param name="id">Id da usuario</param>
        /// <returns>usuario</returns>
        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Usuario.FirstOrDefault(c => c.IdUsuario == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// edita uma usuario ja existente
        /// </summary>
        /// <param name="usuario">usuario a ser editada</param>
        public void Editar(Usuario usuario)
        {
            try
            {

                Usuario usuarioTemp = BuscarPorId(usuario.IdUsuario);


                if (usuarioTemp == null)
                    throw new Exception("Instituição não encontrada");

                //Caso exista, fará a alteração
                usuarioTemp.Nome = usuario.Nome;
                usuarioTemp.Email = usuario.Email;
                usuarioTemp.Senha = usuario.Senha;
    
                _ctx.Usuario.Update(usuarioTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista as instituicoes ja criadas
        /// </summary>
        /// <returns>lista de instituicoes</returns>
        public List<Usuario> Listar()
        {
            try
            {
                return _ctx.Usuario.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// remove uma usuario pelo seu id
        /// </summary>
        /// <param name="id">id da usuario</param>
        public void Remover(Guid id)
        {
            try
            {

                Usuario usuarioTemp = BuscarPorId(id);

                if (usuarioTemp == null)
                    throw new Exception("usuario não encontrada");


                _ctx.Usuario.Remove(usuarioTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
