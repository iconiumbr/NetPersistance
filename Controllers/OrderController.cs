using FiapStore.DTO;
using FiapStore.Entity;
using FiapStore.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private IOrderRepository _orderRepository;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderRepository orderRepository, ILogger<OrderController> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("getOrder/{id}")]
        public IActionResult GetOrder(int id)
        {
            return Ok(_orderRepository.GetById(id));
        }

        [HttpGet]
        [Route("getAllOrders")]
        public IActionResult GetAllOrders()
        {
            return Ok(_orderRepository.GetAll());

        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderDTO order)
        {
            try
            {
                _orderRepository.Create(new Entity.Order(order));
                return Ok("sucessfully created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Create Order");
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public IActionResult UpdateOrder([FromBody] UpdateOrderDTO order) 
        {
            _orderRepository.Update(new Entity.Order(order));
            return Ok("sucessfully updated");

        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
            return Ok("sucessfully deleted");

        }


    }
}
