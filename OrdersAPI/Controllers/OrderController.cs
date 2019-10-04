using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersModel.Model;
using OrdersModel.Repositories.Interface;

namespace OrdersAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {

        private IRepositoryWrap _repositoryWrap;
        public OrderController(IRepositoryWrap repositoryWrap)
        {
            _repositoryWrap = repositoryWrap;
        }
        #region Logger

        ILog logger = log4net.LogManager.GetLogger(typeof(AuthorizationController));

        #endregion
        /// <summary>
        /// Return a list of orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Bearer")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetOrders() {
            try
            {
                var orders = _repositoryWrap.Order.FindAll();
                return Ok(orders);

            }
            catch (Exception ex)
            {


                logger.Error($"Something went wrong inside getOrders action: {ex.Message}");
                return BadRequest("Internal server error");
            }

        }

        /// <summary>
        /// Return a Order filter by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize("Bearer")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetOrderById(int id)
        {
            try
            {
                var order = _repositoryWrap.Order.FindByID(id);
                if (order == null) {
                    return BadRequest("Invalid Order ID");
                }
                return Ok(order);

            }
            catch (Exception ex)
            {


                logger.Error($"Something went wrong inside getOrderById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }
        /// <summary>
        /// Create or Update a Order
        /// if an ID is provided the order is updated
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreateOrder([FromBody]Order order)
        {
            try
            {
                
                if (order ==null)
                {
                    logger.Error("order object sent from client is null.");
                    return BadRequest("Invalid Order");
                }

                if (!ModelState.IsValid)
                {
                    logger.Error("Invalid order object sent from client.");
                    return BadRequest("Invalid Order");
                }
                var listErrors = _repositoryWrap.Order.ValidateOrder(order);
                if (listErrors.Count == 0)
                {
                    _repositoryWrap.Order.Create(order);
                    _repositoryWrap.Save();
                    return Ok(new { id = order.Id });
                }
                else {
                    logger.Error("Invalid order validation " + string.Join(",", listErrors.ToArray()) );
                    return BadRequest("Invalid order validation " + string.Join(", ", listErrors.ToArray()));
                }

              
            }
            catch (Exception ex)
            {
                logger.Error($"Something went wrong inside CreateOrder action: {ex.Message}");
                return BadRequest("Internal server error");
            }
        }
    }
}