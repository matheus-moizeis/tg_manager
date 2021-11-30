#region Namespaces

using Manager.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace Manager.Services.Interfaces
{
    public interface IUserService
    {
        #region Métodos

        Task<UserDTO> Create(UserDTO userDTO);

        Task<UserDTO> Update(UserDTO userDTO);

        Task Remove(long id);

        Task<UserDTO> Get(long id);

        Task<List<UserDTO>> Get();

        Task<List<UserDTO>> SearchByName(string name);

        Task<List<UserDTO>> SearchByEmail(string email);

        Task<UserDTO> GetByEmail(string email);

        #endregion
    }
}
