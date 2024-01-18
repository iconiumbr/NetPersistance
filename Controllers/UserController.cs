using FiapStore.DTO;
using FiapStore.Entity;
using FiapStore.Enums;
using FiapStore.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        /// <summary>
        /// Get data from a single user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Authorize(Roles = Permissions.Admin)]
        [Route("getUser/{id}")]
        public IActionResult GetUser(int id)
        {
            return Ok(_userRepository.GetById(id));
        }

        /// <summary>
        /// Get All users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Authorize(Roles = Permissions.Common)]
        [Route("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userRepository.GetAll());
        }

        /// <summary>
        /// Get a user with its orders
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Authorize(Roles = $"{Permissions.Admin}, {Permissions.Common}")]
        [Route("getWithOrders")]
        public IActionResult GetUsersWithOrders(int id)
        {
            return Ok(_userRepository.GetWithOrders(id));

        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// Example:
        /// <response code="200">Returns Success</response>
        /// 
        /// 
        /// </remarks>
        [HttpPost]
        [Authorize]
        [Authorize(Roles = Permissions.Admin)]
        public IActionResult CreateUser([FromBody] CreateUserDTO user)
        {
            _userRepository.Create(new Entity.User(user));
            return Ok("sucessfully created");

        }

        /// <summary>
        /// Update a existing user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [Authorize(Roles = Permissions.Admin)]
        public IActionResult UpdateUser([FromBody] UpdateUserDTO user) 
        {
            _userRepository.Update(new Entity.User(user));
            return Ok("sucessfully updated");

        }
        
        [HttpDelete("{id}")]
        [Authorize]
        [Authorize(Roles = Permissions.Admin)]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.Delete(id);
            return Ok("sucessfully deleted");

        }


    }
}
