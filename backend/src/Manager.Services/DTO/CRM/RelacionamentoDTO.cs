#region Namespaces

using Manager.Domain.Entities;
using System;

#endregion

namespace Manager.Services.DTO
{
    public class RelacionamentoDTO
    {
        #region Propriedades

        public long Id { get; set; }

        public long ClienteId { get; set; }

        public long FuncionarioId { get; set; }

        public Cliente Cliente { get; set; }

        public Funcionario Funcionario { get; set; }

        public string Observacao { get; set; }

        public bool Finalizado { get; set; }

        public DateTime DtInicio { get; set; }

        public DateTime DtConclusao { get; set; }

        public DateTime DtRetorno { get; set; }

        #endregion

        #region Construtores

        public RelacionamentoDTO(
            long id,
            long clienteId,
            long funcionarioId,
            string observacao,
            bool finalizado,
            DateTime dtInicio,
            DateTime dtConclusao,
            DateTime dtRetorno)

        {
            Id = id;
            ClienteId = clienteId;
            FuncionarioId = funcionarioId;
            Observacao = observacao;
            Finalizado = finalizado;
            DtInicio = dtInicio;
            DtConclusao = dtConclusao;
            DtRetorno = dtRetorno;
        }
        public RelacionamentoDTO()
        {

        }
        #endregion
    }
}
