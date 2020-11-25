
using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using ProjetoEduX.Utils;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux.Repositories
{
    public class RankingRepository : IRankingRepository
    {
        private readonly EduXContext _ctx = new EduXContext();
        public void Adicionar(Ranking ranking)
        {
            try
            {

                _ctx.Ranking.Add(ranking);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Ranking BuscarPorId(Guid id)
        {

            try
            {
                return _ctx.Ranking.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }

        }

        public void Editar(Ranking ranking)
        {
            {
                try
                {
                    Ranking rankingTemp = BuscarPorId(ranking.IdRanking);

                    if (rankingTemp == null)
                        throw new Exception("Ranking não encontrada.");

                    _ctx.Ranking.Update(rankingTemp);
                    _ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message); ;
                }
            }
        }

        public void Excluir(Guid id)
        {
            try
            {
                Ranking ranking = BuscarPorId(id);

                if (ranking == null)
                    throw new Exception("Ranking não encontrada");

                _ctx.Ranking.Remove(ranking);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }

        public List<Ranking> Listar()
        {
            try
            {
                List<Ranking> Ranking = _ctx.Ranking.ToList();
                return Ranking;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}