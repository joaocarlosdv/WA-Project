using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mappings
{
    public class GrupoSegurancaEmpresaMap : IEntityTypeConfiguration<GrupoSegurancaEmpresa>
    {
        public void Configure(EntityTypeBuilder<GrupoSegurancaEmpresa> builder)
        {
            builder.ToTable("GrupoSegurancaEmpresa");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.Id_GrupoSeguranca).HasColumnName("Id_GrupoSeguranca");
            builder.Property(x => x.Id_Empresa).HasColumnName("Id_Empresa");
            builder.Property(x => x.AlteracaoUsuario).HasColumnName("AlteracaoUsuario").HasMaxLength(100).IsUnicode(false);
            builder.Property(x => x.AlteracaoDataHora).HasColumnName("AlteracaoDataHora").HasColumnType("datetime");

            builder.HasOne(x => x.GrupoSeguranca).WithMany(y => y.GrupoSegurancaEmpresa).HasForeignKey(d => d.Id_GrupoSeguranca).HasConstraintName("FKGrupoSegurancaEmpresa01");
            builder.HasOne(x => x.Empresa).WithMany(y => y.GrupoSegurancaEmpresa).HasForeignKey(d => d.Id_Empresa).HasConstraintName("FKGrupoSegurancaEmpresa02");
        }
    }
}
