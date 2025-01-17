﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MMTAPI.Models.Database
{
    /// <summary>
    /// Entity mapping for product table
    /// </summary>
    [Table("products")]
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal PackHeight { get; set; }
        public decimal PackWidth { get; set; }
        public decimal PackWeight { get; set; }
        public string Colour { get; set; }
        public string Size { get; set; }
    }
}