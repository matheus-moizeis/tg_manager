#region Namespaces

using Manager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion


namespace Manager.Infra.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<List<Cliente>> SearchByNome(string nome);

    }
}
