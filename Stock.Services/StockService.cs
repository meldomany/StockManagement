using Stock.Services.IService;
using StockManagement.DataAccess.IRepository;

namespace Stock.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<IList<StockManagement.Models.Stock>> GetStocks()
        {
            return await _stockRepository.GetStocks();
        }

        public async Task UpdateStocks()
        {
            await _stockRepository.UpdateStocks();
        }
    }
}
