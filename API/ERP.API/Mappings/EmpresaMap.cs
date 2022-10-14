using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Mappings
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.Cnpj).HasColumnName("Cnpj").HasMaxLength(14).IsUnicode(false);
            builder.Property(x => x.RazaoSocial).HasColumnName("RazaoSocial").HasMaxLength(150).IsUnicode(false);
            builder.Property(x => x.Fantasia).HasColumnName("Fantasia").HasMaxLength(150).IsUnicode(false);
            builder.Property(x => x.Numero).HasColumnName("Numero").HasMaxLength(15).IsUnicode(false);
            builder.Property(x => x.Cep).HasColumnName("Cep").HasMaxLength(8).IsUnicode(false);
            builder.Property(x => x.Bairro).HasColumnName("Bairro").HasMaxLength(150).IsUnicode(false);
            builder.Property(x => x.Id_Municipio).HasColumnName("Id_Municipio");
            builder.Property(x => x.Fone).HasColumnName("Fone").HasMaxLength(15).IsUnicode(false);
            builder.Property(x => x.InscricaoEstadual).HasColumnName("InscricaoEstadual").HasMaxLength(20).IsUnicode(false);
            builder.Property(x => x.InscricaoMunicipal).HasColumnName("InscricaoMunicipal").HasMaxLength(20).IsUnicode(false);
            builder.Property(x => x.CRT).HasColumnName("CRT").HasMaxLength(20).IsUnicode(false);
            builder.Property(x => x.CNAE).HasColumnName("CNAE").HasMaxLength(20).IsUnicode(false);
            builder.Property(x => x.AlteracaoUsuario).HasColumnName("AlteracaoUsuario").HasMaxLength(100).IsUnicode(false);
            builder.Property(x => x.AlteracaoDataHora).HasColumnName("AlteracaoDataHora").HasColumnType("datetime");

            builder.HasOne(x => x.Municipio).WithMany(y => y.Empresas).HasForeignKey(d => d.Id_Municipio).HasConstraintName("FKEmpresa01");
        }
    }
}
