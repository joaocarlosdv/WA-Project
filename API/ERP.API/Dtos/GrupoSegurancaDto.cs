using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class GrupoSegurancaDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Boolean Ativo { get; set; }
        public string AlteracaoUsuario { get; set; }
        public DateTime AlteracaoDataHora { get; set; }

        public virtual List<GrupoSegurancaUsuarioDto> GrupoSegurancaUsuario { get; set; }
        public virtual List<GrupoSegurancaTransacaoDto> GrupoSegurancaTransacao { get; set; }
        public virtual List<GrupoSegurancaEmpresaDto> GrupoSegurancaEmpresa { get; set; }
    }
}
