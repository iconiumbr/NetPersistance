using FiapStore.DTO;
using FiapStore.Interface;
using FiapStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Autenticate([FromBody] LoginDTO loginDTO) 
        {
            var user = _userRepository.GetWithUserPassword(
                loginDTO.UserName, loginDTO.Password);

            if (user == null) return NotFound("User or password incorrect");

            var token = _tokenService.GetToken(user);
            return Ok(token);
        }
    }
}
