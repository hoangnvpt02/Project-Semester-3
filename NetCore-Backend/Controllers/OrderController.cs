using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Backend.Models;
using NetCore_Backend.Services;

namespace NetCore_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_orderRepository.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var order = _orderRepository.GetById(id);
                if (order != null)
                {
                    return Ok(order);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(OrderModel orderModel)
        {

            try
            {
                _orderRepository.Update(orderModel);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _orderRepository.Delete(id);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(OrderModel orderModel)
        {
            try
            {
                return Ok(_orderRepository.Add(orderModel));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetQuantityOrder")]
        public IActionResult GetQuantityOrder()
        {
            try
            {
                return Ok(_orderRepository.GetQuantityOrder());
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
