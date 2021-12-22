#region Namespaces

using Manager.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Manager.API.ViewModels
{
    public class UpdateRelacionamentoViewModel
    {
        [Required(ErrorMessage = "O Id não pode ser vazio.")]
        [Range(1, int.MaxValue, ErrorMessage = "O id não pode ser menor que 1.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O código do cliente não pode ser vazio.")]
        public long ClienteId { get; set; }

        [Required(ErrorMessage = "O código do funcionario não pode ser vazio.")]
        public long FuncionarioId { get; set; }

        public string Observacao { get; set; }

        public bool Finalizado { get; set; }

        public DateTime DtInicio { get; set; }

        public DateTime DtConclusao { get; set; }

        public DateTime DtRetorno { get; set; }
    }
}
