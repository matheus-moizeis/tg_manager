#region Namespaces

using Manager.Core.Exceptions;
using Manager.Domain.Validators;
using System;

#endregion

namespace Manager.Domain.Entities
{
    public class Funcionario : Base
    {
        #region Propriedades

        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public DateTime? DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        #endregion

        #region Construtores

        public Funcionario(string nome, bool ativo, DateTime dataCadastro, DateTime dataAlteracao)
        {
            Nome = nome;
            Ativo = ativo;
            DataCadastro = dataCadastro;
            DataAlteracao = dataAlteracao;

            Validate();
        }

        public Funcionario()
        {

        }

        #endregion

        #region Métodos

        public void changeNome(string nome)
        {
            Nome = nome;
            Validate();

        }

        public void changeAtivo(bool ativo)
        {
            Ativo = ativo;
        }

        public void changeDataCadastro(DateTime dataCadastro)
        {
            DataCadastro = dataCadastro;
        }

        public void changeDataAlteracao(DateTime dataAlteracao)
        {
            DataAlteracao = dataAlteracao;
        }

        #region Valida

        public override bool Validate()
        {
            var validator = new FuncionarioValidator();
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

        #endregion
    }
}
