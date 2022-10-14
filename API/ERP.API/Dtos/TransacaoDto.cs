using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class TransacaoDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Menu { get; set; }
        public string Descricao { get; set; }
        public Boolean Ativo { get; set; }
        public string AlteracaoUsuario { get; set; }
        public DateTime AlteracaoDataHora { get; set; }
    }
}
