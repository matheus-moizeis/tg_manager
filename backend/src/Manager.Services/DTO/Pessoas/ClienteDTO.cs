namespace Manager.Services.DTO
{
    public class ClienteDTO
    {
        #region Propriedades

        public long Id { get; set; }

        public string Nome { get; set; }

        public float Cpf { get; set; }

        public string Endereco { get; set; }

        public float Telefone { get; set; }

        public bool Ativo { get; set; }

        #endregion

        #region Construtores

        public ClienteDTO()
        {  }

        public ClienteDTO(string nome, float cpf, string endereco, float telefone, bool ativo, long id)
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            Telefone = telefone;
            Ativo = ativo;
            Id = id;
        }

        #endregion
    }
}
