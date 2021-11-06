using Microsoft.EntityFrameworkCore;
using MMTAPI.Models;
using MMTAPI.Models.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTAPI.Repositories
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly MMTDBContext _context;

        public OrderItemsRepository(MMTDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Return many order items for the passed in order id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>a collection of order items</returns>
        public async Task<IEnumerable<OrderItem>> GetManyByOrderId(int orderId)
        {
            return await _context.OrderItem
                .Where(x => x.OrderId == orderId)
                .Include(x => x.Product)
                .ToListAsync();
        }

        /// <summary>
        /// Not currently used but handy to have on deck
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OrderItem> GetOneById(int id)
        {
            return await _context.OrderItem.Where(x => x.OrderItemId == id).FirstOrDefaultAsync();
        }

     
    }
}
