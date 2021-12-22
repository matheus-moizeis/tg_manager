#region Namespaces

using Manager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace Manager.Infra.Interfaces
{
    public interface IRelacionamentoRepository : IBaseRepository<Relacionamento>
    {
        Task<List<Relacionamento>> RelacionamentosAtivos();
    }
}
