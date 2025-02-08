using Microsoft.EntityFrameworkCore;
using web_api.Model;

namespace web_api.Data
{
    public interface IProductRepository
    {
        Task<IAsyncEnumerable<Product>> GetAllProductsAsync();
    }
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IAsyncEnumerable<Product>> GetAllProductsAsync()
        {
            return _context.Products.AsAsyncEnumerable();
        }

    }
}