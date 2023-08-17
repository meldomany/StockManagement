namespace StockManagement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int StockID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string PersonName { get; set; }
        public Stock Stock { get; set; }
    }
}
