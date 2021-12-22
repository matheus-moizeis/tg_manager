#region Namespaces

using Manager.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Manager.API.ViewModels
{
    public class CreateRelacionamentoViewModel
    {
        [Required(ErrorMessage = "O código do cliente não pode ser vazio.")]
        public long ClienteId { get; set; }

        [Required(ErrorMessage = "O código do funcionario não pode ser vazio.")]
        public long FuncionarioId { get; set; }

        public string Observacao { get; set; }

        public bool Finalizado { get; set; }

        public DateTime DtRetorno { get; set; }
    }
}
