using StockManagement.Models;


namespace StockManagement.DataAccess.IRepository
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetStocks();
        Task UpdateStocks();
        Task<bool> StockAvailable(int stockId);
    }
}
