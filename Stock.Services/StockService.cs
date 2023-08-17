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

        public IList<StockManagement.Models.Stock> GetStocks()
        {
            return _stockRepository.GetStocks();
        }
    }
}
