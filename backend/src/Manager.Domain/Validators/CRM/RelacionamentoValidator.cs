#region Namespaces

using FluentValidation;
using Manager.Domain.Entities;

#endregion

namespace Manager.Domain.Validators
{
    public class RelacionamentoValidator : AbstractValidator<Relacionamento>
    {
        public RelacionamentoValidator()
        {
            RuleFor(x => x)
                    .NotEmpty()
                    .WithMessage("A entidade não pode ser vazia.")
                    .NotNull()
                    .WithMessage("A entidade não pode ser nula.");
        }
    }
}
