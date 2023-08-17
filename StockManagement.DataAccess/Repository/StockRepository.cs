using Microsoft.EntityFrameworkCore;
using StockManagement.DataAccess.Data;
using StockManagement.DataAccess.IRepository;
using StockManagement.Models;

namespace StockManagement.DataAccess.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StockRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Stock> GetStocks()
        {
            return _dbContext.Stocks.ToList();
        }

        public async Task<bool> StockAvailable(int stockId)
        {
            return (await _dbContext.Stocks.AnyAsync(s => s.ID == stockId)) ? true : false;
        }
    }
}