using ProjetoEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Interfaces
{
    interface IPostagemRepository
    {
        Task<List<Postagem>> Listar();

        Task<Postagem> BuscarPorID(Guid id);

        Task<Postagem> Adicionar(Postagem Postagem);

        Task<Postagem> Editar(Postagem Postagem);

        Task<Postagem> Remover(Postagem Postagem);
    }
}
