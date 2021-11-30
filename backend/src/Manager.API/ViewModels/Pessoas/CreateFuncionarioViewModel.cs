using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class CreateFuncionarioViewModel
    {
        [Required(ErrorMessage = "O nome não pode ser vazio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo ativo não pode ser vazio")]
        public bool Ativo { get; set; }
    }
}
