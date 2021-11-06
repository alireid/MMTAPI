using MMTAPI.Models;
using MMTAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MMTAPI.Models.Database;
using MMTAPI.Services;
using MMTAPI.Helpers;

namespace MMTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;

        public OrderController(IOrderRepository orderRepository, IOrderItemsRepository orderItemsRepository)
        {
            _orderRepository = orderRepository;
            _orderItemsRepository = orderItemsRepository;
        }

        /// <summary>
        /// Get the order detail from the api and db connection
        /// </summary>
        /// <param name="order"></param>
        /// <returns>json containing customer details, order and purchased product list</returns>
        [HttpPost]
        public async Task<IActionResult> GetOrder([FromBody] OrderRequest request)
        {
            // clean the string just in case
            string userEmail = request.User.Trim();

            // Query the API endpoint and get the user details
            var customerDetails = await CustomerService.GetCustomerDetails(userEmail);

            // validation, if nothing returned
            if (customerDetails == null)
            {
                return BadRequest();
            }

            // validation, where the user's email address does not match the customer number, you should treat this as an invalid request and return an appropriate response.
            if (customerDetails.Email != userEmail)
            {
                return BadRequest();
            }

            // Setup return with user data even if no current order
            OrderData orderData = new()
            {
                Customer = new Customer()
                {
                    FirstName = customerDetails.FirstName,
                    LastName = customerDetails.LastName
                }
            };

            // Get the order from the db
            var orderDetail = await _orderRepository.GetLatestByCustomerId(request.CustomerId);

            // If we have an order add to the returned object
            if (orderDetail != null)
            {
                // Get the order items for the order if we have a valid order, foreign key join the products using entity framework
                IEnumerable<OrderItem> orderItems = await _orderItemsRepository.GetManyByOrderId(orderDetail.OrderId);

                // Populate, keep the controller light
                orderData = OrderHelper.PopulateOrderData(orderDetail, orderData, orderItems, customerDetails);
            }

            // return the order detail to be serialised
            return new JsonResult(orderData);
        }
    }
}
