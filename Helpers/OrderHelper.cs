using MMTAPI.Models;
using MMTAPI.Models.API;
using MMTAPI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MMTAPI.Helpers
{
    /// <summary>
    /// Helper class for order data population
    /// </summary>
    public class OrderHelper
    {
        public static OrderData PopulateOrderData(Order order, OrderData orderData, IEnumerable<OrderItem> orderItems, CustomerDetails customerDetails)
        {
            // Create specific format returned json for serialisation
            List<OrderItems> products = new List<OrderItems>();
            foreach (OrderItem i in orderItems)
            {
                string productName = i.Product.ProductName;

                // Override product name if the order is marked as a gift
                if (order.ContainsGift.Equals(true))
                {
                    productName = "Gift";
                }

                products.Add(new OrderItems() { Product = productName, PriceEach = i.Price, Quantity = i.Quantity });
            };

            orderData.Order = new OrderInformation()
            {
                OrderNumber = order.OrderId,
                OrderDate = order.OrderDate,
                DeliveryAddress = string.Format("{0}, {1}, {2}, {3}", customerDetails.HouseNumber, customerDetails.Street, customerDetails.Town, customerDetails.Postcode),
                DeliveryExpected = order.DeliveryExpected,
                OrderItems = products
            };

            return orderData;
        }
    }
}
