using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class CreateClienteViewModel
    {
        [Required(ErrorMessage = "O nome não pode ser vazio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF não pode ser vazio.")]
        public float Cpf { get; set; }

        [Required(ErrorMessage = "O endereco não pode ser vazio.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O telefone não pode ser vazio.")]
        public float Telefone { get; set; }

    }
}
