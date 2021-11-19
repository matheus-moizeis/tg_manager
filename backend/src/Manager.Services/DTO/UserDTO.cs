using System.Text.Json.Serialization;

namespace Manager.Services.DTO
{
    public class UserDTO
    {
        #region Propriedades

        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        
        [JsonIgnore]
        public string Password { get; set; }

        #endregion

        #region Construtores

        public UserDTO()
        { }

        public UserDTO(long id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        #endregion
    }
}
