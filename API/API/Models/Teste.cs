using API.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Teste : BaseEntity
    {
        public Teste() { }
        
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int? AnoAdmissao { get; set; }
        public decimal Salario { get; set; }
        public Boolean Ativo { get; set; }
    }
}
