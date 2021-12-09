#region Namespaces

using FluentValidation;
using Manager.Domain.Entities;

#endregion
namespace Manager.Domain.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x)
                    .NotEmpty()
                    .WithMessage("A entidade não pode ser vazia.")
                    .NotNull()
                    .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Nome)
                    .NotEmpty()
                    .WithMessage("O nome não pode ser vazio.")
                    .NotNull()
                    .WithMessage("O nome não pode ser nulo.")
                    .MinimumLength(3)
                    .WithMessage("O nome deve ter no minímo 3 caracteres.")
                    .MaximumLength(80)
                    .WithMessage("O nome deve ter no máximo 80 caracteres.");

            RuleFor(x => x.Cpf)
                    .NotNull()
                    .WithMessage("Cpf não pode ser nulo");

            RuleFor(x => x.Endereco)
                    .NotEmpty()
                    .WithMessage("O endereço não pode ser vazio.")
                    .NotNull()
                    .WithMessage("O endereço não pode ser nulo.");

            RuleFor(x => x.Telefone)
                    .NotNull()
                    .WithMessage("Telefone não pode ser nulo");

        }
    }
}
