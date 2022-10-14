using API.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Tarefa : BaseEntity
    {
        public string Descricao { get; set; }
        public bool Feito { get; set; }
    }
}
