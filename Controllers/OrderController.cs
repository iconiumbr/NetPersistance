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

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
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
            _orderRepository.Create(new Entity.Order(order));
            return Ok("sucessfully created");

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
