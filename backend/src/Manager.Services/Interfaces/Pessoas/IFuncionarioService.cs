#region Namespaces

using Manager.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace Manager.Services.Interfaces
{
    public interface IFuncionarioService
    {
        #region Métodos

        Task<FuncionarioDTO> Create(FuncionarioDTO FuncionarioDTO);

        Task<FuncionarioDTO> Update(FuncionarioDTO FuncionarioDTO);

        Task Remove(long id);

        Task<FuncionarioDTO> Get(long id);

        Task<List<FuncionarioDTO>> Get();

        Task<List<FuncionarioDTO>> SearchByNome(string nome);
        
        Task<FuncionarioDTO> GetByNome(string nome);

        #endregion
    }
}
