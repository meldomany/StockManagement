namespace Stock.Services.IService
{
    public interface IStockService
    {
        IList<StockManagement.Models.Stock> GetStocks();
    }
}
