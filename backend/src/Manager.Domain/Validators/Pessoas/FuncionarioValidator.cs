#region Namespaces

using FluentValidation;
using Manager.Domain.Entities;

#endregion

namespace Manager.Domain.Validators
{
    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        public FuncionarioValidator()
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

        }
    }
}
