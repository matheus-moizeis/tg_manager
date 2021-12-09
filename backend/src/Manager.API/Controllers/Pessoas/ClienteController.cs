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

namespace Manager.API.Controllers.Pessoas
{
    [ApiController]
    public class ClienteController : Controller
    {
        #region Propriedades

        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;

        #endregion

        #region Construtor

        public ClienteController(IMapper mapper, IClienteService clienteService)
        {
            _mapper = mapper;
            _clienteService = clienteService;
        }

        #endregion

        #region Métodos

        [HttpGet]
        [Authorize]
        [Route("/api/v1/clientes/search-by-nome")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                var allUsers = await _clienteService.SearchByNome(name);

                if (allUsers.Count == 0)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum cliente foi encontrado com o nome informado",
                        Success = false,
                        Data = null
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Cliente encontrado com sucesso!",
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

        #region CRUD   

        [HttpPost]
        [Authorize]
        [Route("/api/v1/clientes/create")]
        public async Task<IActionResult> Create([FromBody] CreateClienteViewModel clienteVM)
        {
            try
            {
                var clienteDTO = _mapper.Map<ClienteDTO>(clienteVM);

                var clienteCreated = await _clienteService.Create(clienteDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Cliente criado com sucesso",
                    Success = true,
                    Data = new
                    {
                        Id = clienteCreated.Id,
                        Name = clienteCreated.Nome,
                        Ativo = clienteCreated.Ativo
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
        [Route("/api/v1/clientes/update")]
        public async Task<IActionResult> Update([FromBody] UpdateClienteViewModel clienteVM)
        {
            try
            {
                var clienteDTO = _mapper.Map<ClienteDTO>(clienteVM);

                var clienteUpdated = await _clienteService.Update(clienteDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Cliente atualizado com sucesso!",
                    Success = true,
                    Data = clienteUpdated
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
        [Route("/api/v1/clientes/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allClientes = await _clienteService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Clientes encontrados com sucesso!",
                    Success = true,
                    Data = allClientes
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
        [Route("/api/v1/clientes/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            var user = await _clienteService.Get(id);

            if (user == null)
                return BadRequest(new ResultViewModel
                {
                    Message = "Nenhum cliente foi encontrado com o ID informado.",
                    Success = false,
                    Data = user
                });

            try
            {
                await _clienteService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Cliente removido com sucesso!",
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
