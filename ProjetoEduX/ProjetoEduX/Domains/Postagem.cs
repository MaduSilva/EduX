using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjetoEduX.Domains
{
    public partial class Postagem
    {           

        public Guid IdPostagem { get; set; }
        public string Texto { get; set; }
        public string Titulo { get; set; }
        public Guid IdUsuario { get; set; }

        public Guid IdCurtida { get; set; }

        [NotMapped]
        [JsonIgnore]

        public IFormFile Imagem { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string UrlImagem { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Curtida IdCurtidaNavigation { get; set; }
    }
}
