#region Namespaces

using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace Manager.Infra.Repositories
{
    public class FuncionarioRespository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        #region Propriedades

        private readonly ManagerContext _context;

        #endregion

        #region Construtor

        public FuncionarioRespository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Métodos

        public async Task<List<Funcionario>> SearchByNome(string nome)
        {
            var allUsers = await _context.Funcionarios
                                   .Where
                                   (x => x.Nome.ToLower().Contains(nome.ToLower()))
                                    .AsNoTracking()
                                    .ToListAsync();

            return allUsers;
        }

        public async Task<Funcionario> GetByNome(string nome)
        {
            var funcionario = await _context.Funcionarios
                                   .Where
                                   (
                                        x =>
                                            x.Nome.ToLower() == nome.ToLower()
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();

            return funcionario.FirstOrDefault();
        }

        public override async Task<Funcionario> Create(Funcionario obj)
        {
            var funcionario =_context.Add(obj);

            obj.DataCadastro = DateTime.Now;
            obj.DataAlteracao = DateTime.Now;

            await _context.SaveChangesAsync();

            return obj;
        }

        public override async Task<Funcionario> Update(Funcionario obj)
        {
            obj.DataAlteracao = DateTime.Now;
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }

        #endregion
    }
}
