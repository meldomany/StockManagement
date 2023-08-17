using StockManagement.Models.DTOs.Stock;

namespace StockManagement.Models.DTOs.Order
{
    public class OrderDto
    {
        public int StockID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string PersonName { get; set; }
        public StockDto Stock { get; set; }
    }
}
