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
    public class ClienteRespository : BaseRepository<Cliente>, IClienteRepository
    {
        #region Propriedades

        private readonly ManagerContext _context;

        #endregion

        #region Construtor

        public ClienteRespository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos

        public async Task<List<Cliente>> SearchByNome(string nome)
        {
            var allClientes = await _context.Clientes
                                   .Where
                                   (x => x.Nome.ToLower().Contains(nome.ToLower()))
                                    .AsNoTracking()
                                    .ToListAsync();
            return allClientes;
        }
        #endregion
    }
}
