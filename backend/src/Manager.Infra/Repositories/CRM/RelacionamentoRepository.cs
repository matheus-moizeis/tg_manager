#region Namespaces

using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace Manager.Infra.Repositories
{
    public class RelacionamentoRepository : BaseRepository<Relacionamento>, IRelacionamentoRepository
    {
        #region Propriedades

        private readonly ManagerContext _context;

        #endregion

        #region Construtor

        public RelacionamentoRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos

        public async Task<List<Relacionamento>> RelacionamentosAtivos()
        {
            var relacionamentosAtivos = await _context.Relacionamentos
                                                .Where
                                                (x => x.Finalizado != true)
                                                .AsNoTracking()
                                                .ToListAsync();
            return relacionamentosAtivos;

        }


        #endregion
    }
}
