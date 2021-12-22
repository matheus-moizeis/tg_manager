#region Namespaces

using Manager.Core.Exceptions;
using Manager.Domain.Validators;
using System;

#endregion

namespace Manager.Domain.Entities
{
    public class Relacionamento : Base
    {
        #region Propriedades

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

        public Relacionamento(
            long clienteId,
            long funcionarioId,
            string observacao,
            bool finalizado,
            DateTime dtInicio,
            DateTime dtConclusao,
            DateTime dtRetorno
            )
        {
            ClienteId = clienteId;
            FuncionarioId = funcionarioId;
            Observacao = observacao;
            Finalizado = finalizado;
            DtInicio = DateTime.Now;
            DtConclusao = dtConclusao;
            DtRetorno = dtRetorno;
        }

        public Relacionamento()
        {

        }

        #endregion

        #region Metodos

        public override bool Validate()
        {
            var validator = new RelacionamentoValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);

                    throw new DomainException("Campos inválidos, favor verificar", _errors);

                }
            }
            return true;
        }

        #endregion
    }
}
