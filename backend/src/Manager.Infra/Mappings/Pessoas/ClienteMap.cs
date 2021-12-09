#region Namespaces

using Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace Manager.Infra.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TB_CLIENTE");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .UseIdentityColumn()
                   .HasColumnType("BIGINT");

            builder.Property(x => x.Nome)
                   .IsRequired()
                   .HasMaxLength(80)
                   .HasColumnName("nome")
                   .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.Cpf)
                   .IsRequired()
                   .HasMaxLength(11)
                   .HasColumnName("cpf")
                   .HasColumnType("FLOAT(11)");

            builder.Property(x => x.Endereco)
                   .IsRequired()
                   .HasMaxLength(80)
                   .HasColumnName("endereco")
                   .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.Telefone)
                   .IsRequired()
                   .HasMaxLength(20)
                   .HasColumnName("telefone")
                   .HasColumnType("FLOAT(20)");

            builder.Property(x => x.Ativo)
                    .IsRequired()
                    .HasColumnName("ativo")
                    .HasColumnType("CHAR(1)");

        }
    }
}
