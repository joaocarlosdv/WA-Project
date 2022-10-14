using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mappings
{
    public class TesteMap : IEntityTypeConfiguration<Teste>
    {
        public void Configure(EntityTypeBuilder<Teste> builder)
        {
            builder.ToTable("Teste");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnName("Nome").HasMaxLength(50).IsUnicode(false);
            builder.Property(x => x.DataNascimento).HasColumnName("DataNascimento").HasColumnType("datetime");
            builder.Property(x => x.AnoAdmissao).HasColumnName("AnoAdmissao");
            builder.Property(x => x.Salario).HasColumnName("Salario").HasColumnType("numeric(17,2)");
            builder.Property(x => x.Ativo).HasColumnName("Ativo").HasColumnType("bit");

            //builder.Property(x => x.AlteracaoUsuario)
            //    .HasColumnName("AlteracaoUsuario")
            //    .HasMaxLength(100)
            //    .IsUnicode(false);

            //builder.Property(x => x.AlteracaoDataHora)
            //    .HasColumnName("AlteracaoDataHora")
            //    .HasColumnType("datetime");

            builder.Ignore(u => u.AlteracaoUsuario);
            builder.Ignore(u => u.AlteracaoDataHora);

        }
    }
}
