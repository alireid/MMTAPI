using Microsoft.EntityFrameworkCore;
using MMTAPI.Models;
using MMTAPI.Models.Database;
using System.Linq;
using System.Threading.Tasks;

namespace MMTAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MMTDBContext _context;

        public ProductRepository(MMTDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get a single product by id, not currently used as using EF foreign key join in the entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns>product</returns>
        public async Task<Product> GetByProductId(int id)
        {
            return await _context.Product.Where(x => x.ProductId == id).FirstOrDefaultAsync();
        }


    }
}
