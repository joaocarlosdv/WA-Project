using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Boolean Ativo { get; set; }
        public string AlteracaoUsuario { get; set; }
        public DateTime AlteracaoDataHora { get; set; }
    }
}
