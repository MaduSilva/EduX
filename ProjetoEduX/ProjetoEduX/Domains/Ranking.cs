using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjetoEduX.Domains
{
    public partial class Ranking
    {

        public Guid IdRanking { get; set; }
        public string Posicao { get; set; }
        public string QuantidadeTotal { get; set; }
        public string Descricao { get; set; }
        public Guid IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }

    }
}
