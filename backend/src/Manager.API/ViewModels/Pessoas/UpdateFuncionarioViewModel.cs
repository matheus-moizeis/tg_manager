using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class UpdateFuncionarioViewModel
    {
        [Required(ErrorMessage = "O Id não pode ser vazio.")]
        [Range(1, int.MaxValue, ErrorMessage = "O id não pode ser menor que 1.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome não pode ser vazio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo ativo não pode ser vazio")]
        public bool Ativo { get; set; }


    }
}
