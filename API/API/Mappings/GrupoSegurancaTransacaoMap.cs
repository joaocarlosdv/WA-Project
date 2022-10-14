using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mappings
{
    public class GrupoSegurancaTransacaoMap : IEntityTypeConfiguration<GrupoSegurancaTransacao>
    {
        public void Configure(EntityTypeBuilder<GrupoSegurancaTransacao> builder)
        {
            builder.ToTable("GrupoSegurancaTransacao");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.Id_GrupoSeguranca).HasColumnName("Id_GrupoSeguranca");
            builder.Property(x => x.Id_Transacao).HasColumnName("Id_Transacao");
            builder.Property(x => x.AlteracaoUsuario).HasColumnName("AlteracaoUsuario").HasMaxLength(100).IsUnicode(false);
            builder.Property(x => x.AlteracaoDataHora).HasColumnName("AlteracaoDataHora").HasColumnType("datetime");

            builder.HasOne(x => x.GrupoSeguranca).WithMany(y => y.GrupoSegurancaTransacao).HasForeignKey(d => d.Id_GrupoSeguranca).HasConstraintName("FKGrupoSegurancaTransacao01");
            builder.HasOne(x => x.Transacao).WithMany(y => y.GrupoSegurancaTransacao).HasForeignKey(d => d.Id_Transacao).HasConstraintName("FKGrupoSegurancaTransacao02");
        }
    }
}
