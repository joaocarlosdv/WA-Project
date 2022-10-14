using System;

namespace API.Dtos
{
    public class EmpresaDto
    {
        public int Id { get; set; }
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
        public string AlteracaoUsuario { get; set; }
        public DateTime AlteracaoDataHora { get; set; }

        public virtual MunicipioDto Municipio { get; set; }
    }
}
