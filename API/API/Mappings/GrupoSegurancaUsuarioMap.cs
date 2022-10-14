using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Mappings
{
    public class GrupoSegurancaUsuarioMap : IEntityTypeConfiguration<GrupoSegurancaUsuario>
    {
        public void Configure(EntityTypeBuilder<GrupoSegurancaUsuario> builder)
        {
            builder.ToTable("GrupoSegurancaUsuario");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.Id_GrupoSeguranca).HasColumnName("Id_GrupoSeguranca");
            builder.Property(x => x.Id_Usuario).HasColumnName("Id_Usuario");
            builder.Property(x => x.AlteracaoUsuario).HasColumnName("AlteracaoUsuario").HasMaxLength(100).IsUnicode(false);
            builder.Property(x => x.AlteracaoDataHora).HasColumnName("AlteracaoDataHora").HasColumnType("datetime");

            builder.HasOne(x => x.GrupoSeguranca).WithMany(y => y.GrupoSegurancaUsuario).HasForeignKey(d => d.Id_GrupoSeguranca).HasConstraintName("FKGrupoSegurancaUsuario01");
            builder.HasOne(x => x.Usuario).WithMany(y => y.GrupoSegurancaUsuario).HasForeignKey(d => d.Id_Usuario).HasConstraintName("FKGrupoSegurancaUsuario02");
        }
    }
}
