#region Namespaces

using Manager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace Manager.Infra.Interfaces
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        Task<List<Funcionario>> SearchByNome(string nome);

        Task<Funcionario> GetByNome(string nome);
    }
}
