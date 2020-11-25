using System;
using System.Collections.Generic;

namespace ProjetoEduX.Domains
{
    public partial class Curtida

    {
        public Guid IdCurtida { get; set; }
       
        public string Numero { get; set; }

        public virtual ICollection<Postagem> Postagem { get; set; }
    }
}
