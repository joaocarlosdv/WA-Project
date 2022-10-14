using API.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Empresa : BaseEntity
    {
        public Empresa() { }

        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public int Id_Municipio { get; set; }
        public string Fone { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string CRT { get; set; }
        public string CNAE { get; set; }

        public virtual Municipio Municipio { get; set; }
        public virtual List<GrupoSegurancaEmpresa> GrupoSegurancaEmpresa { get; set; }
    }
}
