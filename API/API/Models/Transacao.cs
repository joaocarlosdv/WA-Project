using API.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Transacao : BaseEntity
    {
        public string Codigo { get; set; }
        public string Menu { get; set; }
        public string Descricao { get; set; }
        public Boolean Ativo { get; set; }  
        
        public virtual List<GrupoSegurancaTransacao> GrupoSegurancaTransacao { get; set; }
    }
}
