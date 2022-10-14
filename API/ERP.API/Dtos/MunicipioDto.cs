using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class MunicipioDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public string AlteracaoUsuario { get; set; }
        public DateTime AlteracaoDataHora { get; set; }
    }
}
