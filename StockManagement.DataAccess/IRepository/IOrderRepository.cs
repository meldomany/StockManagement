using StockManagement.Models;

namespace StockManagement.DataAccess.IRepository
{
    public interface IOrderRepository
    {
        Task<IList<Order>> GetOrders();
        Task<Order> CreateOrder(Order order);
        Task<IList<Order>> GetOrdersByStockID(int stockID);
        Task<Order> GetOrderByID(int orderId);
    }
}
