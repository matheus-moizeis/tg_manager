#region Namespaces

using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Manager.Services.Services
{
    public class RelacionamentoService : IRelacionamentoService
    {
        #region Propriedades

        private readonly IMapper _mapper;
        private readonly IRelacionamentoRepository _repository;

        #endregion

        #region Construtor

        public RelacionamentoService(IMapper mapper, IRelacionamentoRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        #endregion

        #region Métodos

        public async Task<RelacionamentoDTO> Get(long id)
        {
            var relacionamento = await _repository.Get(id);

            return _mapper.Map<RelacionamentoDTO>(relacionamento);
        }

        public async Task<List<RelacionamentoDTO>> RelacionamentosAtivos()
        {
            var relacionamentosAtivos = await _repository.RelacionamentosAtivos();

            return _mapper.Map<List<RelacionamentoDTO>>(relacionamentosAtivos);
        }

        #region CRUD

        public async Task<RelacionamentoDTO> Create(RelacionamentoDTO relacionamentoDTO)
        {
            var relacionamentoNovo = _mapper.Map<Relacionamento>(relacionamentoDTO);
            relacionamentoNovo.Validate();

            var relacionamentoCreated = await _repository.Create(relacionamentoNovo);

            return _mapper.Map<RelacionamentoDTO>(relacionamentoCreated);
        }

        public async Task<List<RelacionamentoDTO>> Get()
        {
            var allRelacionamentos = await _repository.Get();

            return _mapper.Map<List<RelacionamentoDTO>>(allRelacionamentos);
        }

        public async Task<RelacionamentoDTO> Update(RelacionamentoDTO relacionamentoDTO)
        {
            var relacionamentoExists = await _repository.Get(relacionamentoDTO.Id);

            if (relacionamentoExists == null)
                throw new DomainException("Não existe nenhum cliente com o id informado!");

            var relacionamento = _mapper.Map<Relacionamento>(relacionamentoDTO);

            relacionamento.Validate();

            var relacionamentoUpdated = await _repository.Update(relacionamento);

            return _mapper.Map<RelacionamentoDTO>(relacionamentoUpdated);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }

        #endregion

        #endregion
    }
}
