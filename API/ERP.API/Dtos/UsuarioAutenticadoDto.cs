using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class UsuarioAutenticadoDto
    {
        public UsuarioDto Usuario { get; set; }
        public bool Autenticado { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public string Token { get; set; }

        public virtual List<TransacaoDto> Transacoes { get; set; }
        public virtual List<string> Grupos { get; set; }

        public UsuarioAutenticadoDto()
        {
            Transacoes = new List<TransacaoDto>();
            Grupos = new List<string>();
        }
    }
}
