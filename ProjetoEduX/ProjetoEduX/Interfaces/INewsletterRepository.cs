using ProjetoEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Interfaces
{
    interface INewsletterRepository
    {
        List<Newsletter> Listar();

        Newsletter BuscarPorId(Guid id);
        void Adicionar(Newsletter newsletter);
        void Editar(Newsletter newsletter);
        void Remover(Guid id);
    }
}
