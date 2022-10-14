using API.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Municipio : BaseEntity
    {
        public Municipio() { }

        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }

        public virtual List<Empresa> Empresas { get; set; }
    }
}
