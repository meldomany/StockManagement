using StockManagement.Models;


namespace StockManagement.DataAccess.IRepository
{
    public interface IStockRepository
    {
        IList<Stock> GetStocks();
        Task<bool> StockAvailable(int stockId);
    }
}
