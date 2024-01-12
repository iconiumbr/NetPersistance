using FiapStore.DTO;
using FiapStore.Entity;
using FiapStore.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("getUser/{id}")]
        public IActionResult GetUser(int id)
        {
            return Ok(_userRepository.GetById(id));
        }

        [HttpGet]
        [Route("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userRepository.GetAll());

        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDTO user)
        {
            _userRepository.Create(new Entity.User(user));
            return Ok("sucessfully created");

        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] User user) 
        {
            _userRepository.Update(user);
            return Ok("sucessfully updated");

        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.Delete(id);
            return Ok("sucessfully deleted");

        }


    }
}
