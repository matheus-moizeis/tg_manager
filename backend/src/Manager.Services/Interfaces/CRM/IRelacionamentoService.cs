#region Namespaces

using Manager.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace Manager.Services.Interfaces
{
    public interface IRelacionamentoService
    {
        #region Métodos

        Task<RelacionamentoDTO> Create(RelacionamentoDTO RelacionamentoDTO);

        Task<RelacionamentoDTO> Update(RelacionamentoDTO RelacionamentoDTO);

        Task Remove(long id);

        Task<RelacionamentoDTO> Get(long id);

        Task<List<RelacionamentoDTO>> Get();

        Task<List<RelacionamentoDTO>> RelacionamentosAtivos();

        #endregion
    }
}
