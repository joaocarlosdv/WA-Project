using API.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Boolean Ativo { get; set; }

        public virtual List<GrupoSegurancaUsuario> GrupoSegurancaUsuario { get; set; }
    }
}
