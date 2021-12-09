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
    public class ClienteService : IClienteService
    {
        #region Propriedades

        private readonly IMapper _mapper;
        private readonly IClienteRepository _repository;

        #endregion

        #region Construtor

        public ClienteService(IMapper mapper, IClienteRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        #endregion

        #region Métodos

        public async Task<ClienteDTO> Get(long id)
        {
            var cliente = await _repository.Get(id);

            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<List<ClienteDTO>> SearchByNome(string name)
        {
            var todosClientes = await _repository.SearchByNome(name);

            return _mapper.Map<List<ClienteDTO>>(todosClientes);
        }

        #region CRUD

        public async Task<ClienteDTO> Create(ClienteDTO clienteDTO)
        {
            clienteDTO.Ativo = true;
            var clienteNovo = _mapper.Map<Cliente>(clienteDTO);
            clienteNovo.Validate();

            var clienteCreated = await _repository.Create(clienteNovo);

            return _mapper.Map<ClienteDTO>(clienteCreated);
        }

        public async Task<List<ClienteDTO>> Get()
        {
            var allClientes = await _repository.Get();

            return _mapper.Map<List<ClienteDTO>>(allClientes);
        }

        public async Task<ClienteDTO> Update(ClienteDTO clienteDTO)
        {
            var clienteExists = await _repository.Get(clienteDTO.Id);

            if (clienteExists == null)
                throw new DomainException("Não existe nenhum cliente com o id informado!");

            var cliente = _mapper.Map<Cliente>(clienteDTO);

            cliente.Validate();

            var clienteUpdated = await _repository.Update(cliente);

            return _mapper.Map<ClienteDTO>(clienteUpdated);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }

        #endregion

        #endregion
    }
}
