using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class GrupoSegurancaEmpresaDto
    {
        public int Id { get; set; }
        public int Id_GrupoSeguranca { get; set; }
        public int Id_Empresa { get; set; }
        public string AlteracaoUsuario { get; set; }
        public DateTime AlteracaoDataHora { get; set; }

        public virtual GrupoSegurancaDto GrupoSeguranca { get; set; }
        public virtual EmpresaDto Empresa { get; set; }
    }
}
