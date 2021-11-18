#region Namespaces

using Manager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace Manager.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<List<User>> SearchByEmail(string email);
        Task<List<User>> SearchByName(string name);

    }
}
