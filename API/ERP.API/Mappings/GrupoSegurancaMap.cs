using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mappings
{
    public class GrupoSegurancaMap : IEntityTypeConfiguration<GrupoSeguranca>
    {
        public void Configure(EntityTypeBuilder<GrupoSeguranca> builder)
        {
            builder.ToTable("GrupoSeguranca");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.Descricao).HasColumnName("Descricao").HasMaxLength(100).IsUnicode(false);
            builder.Property(x => x.Ativo).HasColumnName("Ativo").HasColumnType("bit");
            builder.Property(x => x.AlteracaoUsuario).HasColumnName("AlteracaoUsuario").HasMaxLength(100).IsUnicode(false);
            builder.Property(x => x.AlteracaoDataHora).HasColumnName("AlteracaoDataHora").HasColumnType("datetime");            
        }
    }
}
