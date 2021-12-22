#region Namespaces

using Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace Manager.Infra.Mappings
{
    public class RelacionamentoMap : IEntityTypeConfiguration<Relacionamento>
    {
        public void Configure(EntityTypeBuilder<Relacionamento> builder)
        {
            builder.ToTable("TB_RELACIONAMENTO");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Cliente)
                   .WithMany(x => x.Relacionamentos)
                   .HasForeignKey(x => x.ClienteId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Funcionario)
                   .WithMany(f => f.Relacionamentos)
                   .HasForeignKey(x => x.FuncionarioId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Id)
                   .UseIdentityColumn()
                   .HasColumnType("BIGINT");

            builder.Property(x => x.Observacao)
                   .IsRequired()
                   .HasMaxLength(200)
                   .HasColumnName("observacao")
                   .HasColumnType("VARCHAR(200)");

            builder.Property(x => x.Finalizado)
                    .IsRequired()
                    .HasColumnName("finalizado")
                    .HasColumnType("CHAR(1)");

            builder.Property(x => x.DtInicio)
                    .HasColumnName("dtInicio")
                    .HasColumnType("datetime2");

            builder.Property(x => x.DtConclusao)
                    .HasColumnName("dtConclusao")
                    .HasColumnType("datetime2");

            builder.Property(x => x.DtRetorno)
                    .HasColumnName("dtRetorno")
                    .HasColumnType("datetime2");
        }
    }
}
