#region Namespaces

using EscNet.Cryptography.Interfaces;
using Manager.API.Token;
using Manager.API.Utilities;
using Manager.API.ViewModels;
using Manager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

#endregion

namespace Manager.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Propriedades

        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserService _userService;
        private readonly IRijndaelCryptography _rijndaelCryptography;

        #endregion

        #region Construtor

        public AuthController(
            IConfiguration configuration,
            ITokenGenerator tokenGenerator,
            IUserService userService,
            IRijndaelCryptography rijndaelCryptography)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
            _userService = userService;
            _rijndaelCryptography = rijndaelCryptography;
        }

        #endregion

        #region Métodos

        [HttpPost]
        [Route("/api/v1/auth/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
        {

            var user = await _userService.GetByEmail(loginViewModel.Email);

            if (user == null)
                return StatusCode(401, Responses.UnauthorizedErrorMessage());
            
            user.Password = _rijndaelCryptography.Decrypt(user.Password);

            try
            {
                var tokenEmail = user.Email;
                var tokenPassword = user.Password;

                if (loginViewModel.Email == tokenEmail && loginViewModel.Password == tokenPassword)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Usuário autenticado com sucesso!",
                        Success = true,
                        Data = new
                        {
                            Token = _tokenGenerator.GenerateToken(),
                            TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                        }
                    });
                }
                else
                {
                    return StatusCode(401, Responses.UnauthorizedErrorMessage());
                }
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        #endregion

    }
}
