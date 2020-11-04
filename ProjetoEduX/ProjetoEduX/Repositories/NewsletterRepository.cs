using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Repositories
{
    public class NewsletterRepository : INewsletterRepository
    {

        private EduXContext _ctx;
        public NewsletterRepository()
        {
            _ctx = new EduXContext();
        }

        /// <summary>
        /// Cria uma newsletter
        /// </summary>
        /// <param name="newsletter">Newsletter a ser criada</param>
        public void Adicionar(Newsletter newsletter)
        {
            try
            {

                _ctx.Newsletter.Add(newsletter);


                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca uma newsletter pelo Id
        /// </summary>
        /// <param name="id">Id da newsletter</param>
        /// <returns>newsletter</returns>
        public Newsletter BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Newsletter.FirstOrDefault(c => c.IdNewsletter == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// edita uma newsletter ja existente
        /// </summary>
        /// <param name="newsletter">newsletter a ser editada</param>
        public void Editar(Newsletter newsletter)
        {
            try
            {

                Newsletter newsletterTemp = BuscarPorId(newsletter.IdNewsletter);


                if (newsletterTemp == null)
                    throw new Exception("Newsletter não encontrada");

                //Caso exista, fará a alteração
                newsletterTemp.Email = newsletter.Email;

                _ctx.Newsletter.Update(newsletterTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista as newsletter ja criadas
        /// </summary>
        /// <returns>lista de newsletter</returns>
        public List<Newsletter> Listar()
        {
            try
            {
                return _ctx.Newsletter.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// remove uma newsletter pelo seu id
        /// </summary>
        /// <param name="id">id da newsletter</param>
        public void Remover(Guid id)
        {
            try
            {

                Newsletter newsletterTemp = BuscarPorId(id);

                if (newsletterTemp == null)
                    throw new Exception("Newsletter não encontrada");


                _ctx.Newsletter.Remove(newsletterTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
