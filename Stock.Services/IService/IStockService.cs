namespace Stock.Services.IService
{
    public interface IStockService
    {
        Task <IList<StockManagement.Models.Stock>> GetStocks();
        Task UpdateStocks();
    }
}
