using Microsoft.EntityFrameworkCore;
using MMTAPI.Models;
using MMTAPI.Models.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MMTDBContext _context;

        public OrderRepository(MMTDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Not currently used, but handy to have on deck.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Order> GetByOrderId(int id)
        {
            return await _context.Order
                .Where(x => x.OrderId == id)
                .Include(x => x.OrderItems)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Return one order, the latested based on the order date decending, yielded by the customer email which maps to the customerId
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Order</returns>
        public async Task<Order> GetLatestByCustomerId(string email)
        {
            return await _context.Order
                .Where(x => x.CustomerId == email)
                .OrderByDescending(x => x.OrderDate)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        ///  Not currently used, but handy to have on deck.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> GetManyByCustomerId(string email)
        {
            return await _context.Order
                .Where(x => x.CustomerId == email)
                .ToListAsync();
        }
    }
}
