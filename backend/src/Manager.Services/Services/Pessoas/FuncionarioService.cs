#region Namespaces

using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace Manager.Services.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        #region Propriedades
        
        private readonly IMapper _mapper;
        private readonly IFuncionarioRepository _repository;

        #endregion
        
        #region Construtor
        public FuncionarioService(IMapper mapper, IFuncionarioRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        #endregion

        #region Métodos

        public async Task<FuncionarioDTO> Get(long id)
        {
            var funcionario = await _repository.Get(id);

            return _mapper.Map<FuncionarioDTO>(funcionario);
        }

        public async Task<List<FuncionarioDTO>> SearchByNome(string name)
        {
            var todosFuncionarios = await _repository.SearchByNome(name);

            return _mapper.Map<List<FuncionarioDTO>>(todosFuncionarios);
        }

        public async Task<FuncionarioDTO> GetByNome(string nome)
        {
            var funcionario = await _repository.GetByNome(nome);

            return _mapper.Map<FuncionarioDTO>(funcionario);
        }

        #region CRUD

        public async Task<FuncionarioDTO> Create(FuncionarioDTO funcionarioDTO)
        {
            var funcionarioExis = await _repository.GetByNome(funcionarioDTO.Nome);

            if (funcionarioExis != null)
            {
                throw new DomainException("Já existe um funcionário cadastrado com o nome informado");
            }

            var funcionarioNovo = _mapper.Map<Funcionario>(funcionarioDTO);
            funcionarioNovo.Validate();

            var funcionarioCreated = await _repository.Create(funcionarioNovo);

            return _mapper.Map<FuncionarioDTO>(funcionarioCreated);
        }

        public async Task<List<FuncionarioDTO>> Get()
        {
            var allUsers = await _repository.Get();

            return _mapper.Map<List<FuncionarioDTO>>(allUsers);
        }

        public async Task<FuncionarioDTO> Update(FuncionarioDTO funcionarioDTO)
        {
            var funcionarioExists = await _repository.Get(funcionarioDTO.Id);

            if (funcionarioExists == null)
                throw new DomainException("Não existe nenhum usuário com o id informado!");

            var funcionario = _mapper.Map<Funcionario>(funcionarioDTO);

            funcionario.DataCadastro = funcionarioExists.DataCadastro;
            
            funcionario.Validate();


            var funcionarioUpdated = await _repository.Update(funcionario);

            return _mapper.Map<FuncionarioDTO>(funcionarioUpdated);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }

        #endregion

        #endregion
    }
}
