#region Namespaces

using Manager.Core.Exceptions;
using Manager.Domain.Validators;
using System;
using System.Collections.Generic;

#endregion

namespace Manager.Domain.Entities
{
    public class User : Base
    {
        #region Propriedades

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        #endregion

        #region Construtores

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();

            Validate();
        }

        public User()
        {
        }
        #endregion

        #region Métodos

        public void changeName(string name)
        {
            Name = name;
            Validate();
        }

        public void changePassword(string password)
        {
            Password = password;
            Validate();
        }

        public void changeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);

                    throw new DomainException("Campos inválidos, favor verificar" , _errors);

                }
            }
            return true;
        }

        #endregion
    }
}
