using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class UpdateClienteViewModel
    {
        [Required(ErrorMessage = "O Id não pode ser vazio.")]
        [Range(1, int.MaxValue, ErrorMessage = "O id não pode ser menor que 1.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome não pode ser vazio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF não pode ser vazio.")]
        public float Cpf { get; set; }

        [Required(ErrorMessage = "O endereco não pode ser vazio.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O telefone não pode ser vazio.")]
        public float Telefone { get; set; }

        [Required(ErrorMessage = "O campo ativo não pode ser vazio.")]
        public bool Ativo { get; set; }
    }
}
