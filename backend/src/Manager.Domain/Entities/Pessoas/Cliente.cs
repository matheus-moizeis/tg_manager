#region Namespaces

using Manager.Core.Exceptions;
using Manager.Domain.Validators;

#endregion

namespace Manager.Domain.Entities
{
    public class Cliente : Base
    {
        #region Propriedades

        public string Nome { get; set; }

        public float Cpf { get; set; }

        public string Endereco { get; set; }

        public float Telefone { get; set; }

        public bool Ativo { get; set; }

        #endregion

        #region Metodos

        public override bool Validate()
        {
            var validator = new ClienteValidator();
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
