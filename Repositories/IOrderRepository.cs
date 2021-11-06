using MMTAPI.Models.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTAPI.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByOrderId(int id);
        Task<IEnumerable<Order>> GetManyByCustomerId(string email);
        Task<Order> GetLatestByCustomerId(string email);
    }
}
