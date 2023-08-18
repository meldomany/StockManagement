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

        public async Task<List<Stock>> GetStocks()
        {
            var random = new Random();
            var stocks = await _dbContext.Stocks.ToListAsync();
            foreach (var stock in stocks)
            {
                stock.Price = random.Next(1, 101);
            }
            _dbContext.Stocks.UpdateRange(stocks);
            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(stocks);
        }

        public async Task UpdateStocks()
        {
            var random = new Random();
            var stocks = await _dbContext.Stocks.ToListAsync();
            foreach (var stock in stocks)
            {
                stock.Price = random.Next(1, 101);
            }
            _dbContext.Stocks.UpdateRange(stocks);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> StockAvailable(int stockId)
        {
            return (await _dbContext.Stocks.AnyAsync(s => s.ID == stockId)) ? true : false;
        }
    }
}