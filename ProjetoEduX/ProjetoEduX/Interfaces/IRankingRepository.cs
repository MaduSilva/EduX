using ProjetoEduX.Domains;
using System;
using System.Collections.Generic;

namespace ProjetoEduX.Interfaces
{
    interface IRankingRepository
    {
        List<Ranking> Listar();

        Ranking BuscarPorId(Guid id);
        void Adicionar(Ranking ranking);
        void Editar(Ranking ranking);
        void Excluir(Guid id);

    }
}