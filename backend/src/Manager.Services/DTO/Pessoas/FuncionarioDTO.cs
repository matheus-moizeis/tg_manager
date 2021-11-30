using System;

namespace Manager.Services.DTO
{
    public class FuncionarioDTO
    {
        #region Métodos

        public long Id { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public DateTime? DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        #endregion

        #region Construtores
        public FuncionarioDTO()
        { }

        public FuncionarioDTO(long id ,string nome, bool ativo, DateTime? dataCadastro, DateTime? dataAlteracao)
        {
            Id = id;
            Nome = nome;
            Ativo = ativo;
            DataCadastro = dataCadastro;
            DataAlteracao = dataAlteracao;
        }

        #endregion
    }
}
