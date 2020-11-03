using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Repositories
{
    public class PostagemRepository : IPostagemRepository
    {
        public Task<Postagem> Adicionar(Postagem Postagem)
        {
            throw new NotImplementedException();
        }

        public Task<Postagem> BuscarPorID(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Postagem> Editar(Postagem Postagem)
        {
            throw new NotImplementedException();
        }

        public Task<List<Postagem>> Listar()
        {
            throw new NotImplementedException();
        }

        public Task<Postagem> Remover(Postagem Postagem)
        {
            throw new NotImplementedException();
        }
    }
}
