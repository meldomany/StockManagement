using Microsoft.EntityFrameworkCore;
using StockManagement.DataAccess.Data;
using StockManagement.DataAccess.IRepository;
using StockManagement.Models;

namespace StockManagement.DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            var newOrder = await _dbContext.Orders.AddAsync(order);
            return (await _dbContext.SaveChangesAsync() >= 0) ? newOrder.Entity : new Order();
        }

        public async Task<IList<Order>> GetOrders()
        {
            return await _dbContext.Orders.Include(o => o.Stock).ToListAsync();
        }

        public async Task<IList<Order>> GetOrdersByStockID(int stockID)
        {
            return await _dbContext.Orders.Include(o => o.Stock).Where(o => o.StockID == stockID).ToListAsync();
        }

        public async Task<Order> GetOrderByID(int orderId)
        {
            return await _dbContext.Orders.Include(o => o.Stock).FirstAsync(o => o.Id == orderId);
        }
    }
}
