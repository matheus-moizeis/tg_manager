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
    public class RelacionamentoController : Controller
    {
        #region Propriedades

        private readonly IMapper _mapper;
        private readonly IRelacionamentoService _relacionamentoService;

        #endregion

        #region Construtor
        public RelacionamentoController(IMapper mapper, IRelacionamentoService relacionamentoService)
        {
            _mapper = mapper;
            _relacionamentoService = relacionamentoService;
        }

        #endregion

        #region Métodos

        [HttpGet]
        [Authorize]
        [Route("/api/v1/relacionamentos/ativos")]
        public async Task<IActionResult> RelacionamentosAtivos()
        {
            try
            {
                var relacionamentosAtivos = await _relacionamentoService.RelacionamentosAtivos();
                return Ok(new ResultViewModel
                {
                    Message = "Relacionamentos encontrados com sucesso!",
                    Success = true,
                    Data = relacionamentosAtivos
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/relacionamentos/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var relacionamento = await _relacionamentoService.Get(id);

                if (relacionamento == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum relacionamento foi encontrado com o ID informado.",
                        Success = false,
                        Data = relacionamento
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Relacionamento encontrado com sucesso!",
                    Success = true,
                    Data = relacionamento
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
        [Route("/api/v1/relacionamentos/create")]
        public async Task<IActionResult> Create([FromBody] CreateRelacionamentoViewModel relacionamentoVM)
            {
            try
            {
                var relacionamentoDTO = _mapper.Map<RelacionamentoDTO>(relacionamentoVM);

                var relacionamentoCreated = await _relacionamentoService.Create(relacionamentoDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Relacionamento criado com sucesso",
                    Success = true,
                    Data = new
                    {
                        Id = relacionamentoCreated.Id,
                        Obs = relacionamentoCreated.Observacao
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
        [Route("/api/v1/relacionamentos/update")]
        public async Task<IActionResult> Update([FromBody] UpdateRelacionamentoViewModel relacionamentoVM)
        {
            try
            {
                var relacionamentoDTO = _mapper.Map<RelacionamentoDTO>(relacionamentoVM);

                var relacionamentoUpdated = await _relacionamentoService.Update(relacionamentoDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Cliente atualizado com sucesso!",
                    Success = true,
                    Data = relacionamentoUpdated
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
        [Route("/api/v1/relacionamentos/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allRelacionamentos = await _relacionamentoService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Relacionamentos encontrados com sucesso!",
                    Success = true,
                    Data = allRelacionamentos
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
        [Route("/api/v1/relacionamentos/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            var user = await _relacionamentoService.Get(id);

            if (user == null)
                return BadRequest(new ResultViewModel
                {
                    Message = "Nenhum relacionamento foi encontrado com o ID informado.",
                    Success = false,
                    Data = user
                });

            try
            {
                await _relacionamentoService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Relacionamento removido com sucesso!",
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
