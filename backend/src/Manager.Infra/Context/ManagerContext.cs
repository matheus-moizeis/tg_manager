#region Namespaces

using Manager.Domain.Entities;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Manager.Infra.Context
{
    public class ManagerContext : DbContext
    {
        #region Construtores

        public ManagerContext()
        { }

        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        { }

        #endregion

        #region Config. Migrations

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=ManagerApi;User ID=sa;Password=C2BK7cry$");
        }

        #endregion

        #region Tabelas

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }

        #endregion

        #region Config. Tabelas

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new FuncionarioMap());
            builder.ApplyConfiguration(new ClienteMap());
        }

        #endregion
    }
}
