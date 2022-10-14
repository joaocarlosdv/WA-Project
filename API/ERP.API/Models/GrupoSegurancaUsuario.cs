using API.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class GrupoSegurancaUsuario : BaseEntity
    {
        public int Id_GrupoSeguranca { get; set; }
        public int Id_Usuario { get; set; }

        public virtual GrupoSeguranca GrupoSeguranca { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
