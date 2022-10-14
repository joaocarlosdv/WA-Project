using API.Models.Base;
using System;
using System.Collections.Generic;

namespace API.Models
{
    public class GrupoSeguranca : BaseEntity
    {
        public string Descricao { get; set; }
        public Boolean Ativo { get; set; }

        public virtual List<GrupoSegurancaUsuario> GrupoSegurancaUsuario { get; set; }
        public virtual List<GrupoSegurancaTransacao> GrupoSegurancaTransacao { get; set; }
        public virtual List<GrupoSegurancaEmpresa> GrupoSegurancaEmpresa { get; set; }   
    }
}
