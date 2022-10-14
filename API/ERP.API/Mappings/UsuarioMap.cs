using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnName("Nome").HasMaxLength(100).IsUnicode(false);
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(200).IsUnicode(false);
            builder.Property(x => x.Login).HasColumnName("Login").HasMaxLength(100).IsUnicode(false);
            builder.Property(x => x.Senha).HasColumnName("Senha").HasMaxLength(100).IsUnicode(false);
            builder.Property(x => x.Ativo).HasColumnName("Ativo").HasColumnType("bit");
            builder.Property(x => x.AlteracaoUsuario).HasColumnName("AlteracaoUsuario").HasMaxLength(100).IsUnicode(false);
            builder.Property(x => x.AlteracaoDataHora).HasColumnName("AlteracaoDataHora").HasColumnType("datetime");
        }
    }
}
