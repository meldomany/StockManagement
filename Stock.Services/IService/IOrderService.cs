using StockManagement.Models;

namespace Stock.Services.IService
{
    public interface IOrderService
    {
        Task<IList<Order>> GetOrders();
        Task<Order> CreateOrder(Order order);
        Task<IList<Order>> GetOrdersByStockID(int stockID);
        Task<Order> GetOrderByID(int orderId);
    }
}
