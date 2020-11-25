using Microsoft.EntityFrameworkCore;
using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Repositories
{
    public class CursoRepository : ICursoRepository
    {

        private EduXContext _ctx;
        public CursoRepository()
        {
            _ctx = new EduXContext();
        }

        /// <summary>
        /// Cria uma curso
        /// </summary>
        /// <param name="curso">curso a ser criada</param>
        public void Adicionar(Curso curso)
        {
            try
            {
                _ctx.Curso.Add(curso);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca uma curso pelo Id
        /// </summary>
        /// <param name="id">Id da curso</param>
        /// <returns>curso</returns>
        public Curso BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Curso.FirstOrDefault(c => c.IdCurso == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// edita uma curso ja existente
        /// </summary>
        /// <param name="curso">curso a ser editada</param>
        public void Editar(Curso curso)
        {
            try
            {

                Curso cursoTemp = BuscarPorId(curso.IdCurso);


                if (cursoTemp == null)
                    throw new Exception("Curso não encontrado");

                //Caso exista, fará a alteração
                cursoTemp.Titulo = curso.Titulo;
              


                _ctx.Curso.Update(cursoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista as cursos ja criadas
        /// </summary>
        /// <returns>lista de cursos</returns>
        public List<Curso> Listar()
        {
            try
            {
                return _ctx.Curso.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// remove uma curso pelo seu id
        /// </summary>
        /// <param name="id">id da curso</param>
        public void Remover(Guid id)
        {
            try
            {

                Curso cursoTemp = BuscarPorId(id);

                if (cursoTemp == null)
                    throw new Exception("curso não encontrado");


                _ctx.Curso.Remove(cursoTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
