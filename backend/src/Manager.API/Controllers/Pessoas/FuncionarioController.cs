#region Namespaces

using AutoMapper;
using Manager.API.Utilities;
using Manager.API.ViewModels;
using Manager.Core.Exceptions;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

#endregion

namespace Manager.API.Controllers
{
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        #region Propriedades

        private readonly IMapper _mapper;
        private readonly IFuncionarioService _funcionarioService;

        #endregion

        #region Construtor

        public FuncionarioController(IMapper mapper, IFuncionarioService funcionarioService)
        {
            _mapper = mapper;
            _funcionarioService = funcionarioService;
        }

        #endregion

        #region Métodos


        [HttpGet]
        [Authorize]
        [Route("/api/v1/funcionario/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var user = await _funcionarioService.Get(id);

                if (user == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum funcionário foi encontrado com o ID informado.",
                        Success = false,
                        Data = user
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Funcionário encontrado com sucesso!",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/funcionario/search-by-nome")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                var allUsers = await _funcionarioService.SearchByNome(name);

                if (allUsers.Count == 0)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum funcionário foi encontrado com o nome informado",
                        Success = false,
                        Data = null
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Funcionário encontrado com sucesso!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/funcionario/get-by-nome")]
        public async Task<IActionResult> GetByNome([FromQuery] string nome)
        {
            try
            {
                var user = await _funcionarioService.GetByNome(nome);

                if (user == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum funcionário foi encontrado com o nome informado.",
                        Success = false,
                        Data = user
                    });


                return Ok(new ResultViewModel
                {
                    Message = "Funcionário encontrado com sucesso!",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        #region CRUD   

        [HttpPost]
        [Authorize]
        [Route("/api/v1/funcionarios/create")]
        public async Task<IActionResult> Create([FromBody] CreateFuncionarioViewModel funcionarioVM)
        {
            try
            {
                var funcionarioDTO = _mapper.Map<FuncionarioDTO>(funcionarioVM);

                var funcionarioCreated = await _funcionarioService.Create(funcionarioDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com sucesso",
                    Success = true,
                    Data = new
                    {
                        Id = funcionarioCreated.Id,
                        Name = funcionarioCreated.Nome,
                        Ativo = funcionarioCreated.Ativo
                    }
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Authorize]
        [Route("/api/v1/funcionarios/update")]
        public async Task<IActionResult> Update([FromBody] UpdateFuncionarioViewModel funcionarioVM)
        {
            try
            {
                var funcionarioDTO = _mapper.Map<FuncionarioDTO>(funcionarioVM);

                var funcionarioUpdated = await _funcionarioService.Update(funcionarioDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário atualizado com sucesso!",
                    Success = true,
                    Data = funcionarioUpdated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/funcionarios/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allFuncionarios = await _funcionarioService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Usuários encontrados com sucesso!",
                    Success = true,
                    Data = allFuncionarios
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("/api/v1/funcionario/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            var user = await _funcionarioService.Get(id);

            if (user == null)
                return BadRequest(new ResultViewModel
                {
                    Message = "Nenhum funcionário foi encontrado com o ID informado.",
                    Success = false,
                    Data = user
                });

            try
            {
                await _funcionarioService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Funcionário removido com sucesso!",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        #endregion

        #endregion
    }
}
