using System;
using System.Collections.Generic;

namespace MMTAPI.Models
{
    /// <summary>
    /// The model used to be serialised for the response
    /// </summary>
    public class OrderData
    {
        public Customer Customer { get; set; }
        public OrderInformation Order { get; set; }
    }

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class OrderInformation
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public List<OrderItems> OrderItems { get; set; }
        public DateTime DeliveryExpected { get; set; }
    }
    public class OrderItems
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal PriceEach { get; set; }
    }

}