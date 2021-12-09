#region Namespaces

using Manager.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace Manager.Services.Interfaces
{
    public interface IClienteService
    {
        #region Métodos

        Task<ClienteDTO> Create(ClienteDTO ClienteDTO);

        Task<ClienteDTO> Update(ClienteDTO ClienteDTO);

        Task Remove(long id);

        Task<ClienteDTO> Get(long id);

        Task<List<ClienteDTO>> Get();

        Task<List<ClienteDTO>> SearchByNome(string nome);

        #endregion
    }
}
