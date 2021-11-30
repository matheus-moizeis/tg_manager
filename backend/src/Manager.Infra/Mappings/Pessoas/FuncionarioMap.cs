#region Namespaces

using Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace Manager.Infra.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("TB_FUNCIONARIO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                    .UseIdentityColumn()
                    .HasColumnType("BIGINT");

            builder.Property(x => x.Nome)
                   .IsRequired()
                   .HasMaxLength(80)
                   .HasColumnName("nome")
                   .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.Ativo)
                   .IsRequired()
                   .HasColumnName("ativo")
                   .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.DataCadastro)
                    .HasColumnName("dtCadastro")
                    .HasColumnType("smalldatetime");

            builder.Property(x => x.DataAlteracao)
                   .HasColumnName("dtAlteracao")
                   .HasColumnType("smalldatetime");
        }
    }
}
