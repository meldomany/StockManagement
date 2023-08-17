using Stock.Services.IService;
using StockManagement.DataAccess.IRepository;
using StockManagement.Models;

namespace Stock.Services
{
    public class OrderService : IOrderService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IStockRepository stockRepository, IOrderRepository orderRepository)
        {
            _stockRepository = stockRepository;
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            if (await _stockRepository.StockAvailable(order.StockID))
            {
                return await _orderRepository.CreateOrder(order);
            }
            return new Order();
        }

        public async Task<IList<Order>> GetOrders()
        {
            return await _orderRepository.GetOrders();
        }

        public async Task<IList<Order>> GetOrdersByStockID(int stockID)
        {
            if (await _stockRepository.StockAvailable(stockID))
            {
                return await _orderRepository.GetOrdersByStockID(stockID);
            }
            return new List<Order>();
        }

        public async Task<Order> GetOrderByID(int orderId)
        {
            return await _orderRepository.GetOrderByID(orderId);
        }
    }
}