using System.Text.Json.Serialization;

namespace StockManagement.Models
{
    public class Stock
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
