using MMTAPI.Models.Database;
using System.Threading.Tasks;

namespace MMTAPI.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByProductId(int id);
    }
}
