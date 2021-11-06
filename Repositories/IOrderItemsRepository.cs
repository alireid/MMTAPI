using MMTAPI.Models.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTAPI.Repositories
{
    public interface IOrderItemsRepository
    {
        Task<IEnumerable<OrderItem>> GetManyByOrderId(int orderId);
        Task<OrderItem> GetOneById(int id);
    }
}
