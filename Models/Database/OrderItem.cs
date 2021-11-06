using System.ComponentModel.DataAnnotations.Schema;

namespace MMTAPI.Models.Database
{
    /// <summary>
    /// Entity mapping for Order table, foreign key join product
    /// </summary>
    [Table("orderitems")]
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool Returnable { get; set; }

    }
}