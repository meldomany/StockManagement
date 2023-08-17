namespace StockManagement.Models.DTOs.Order
{
    public class OrderCreationDto
    {
        public int StockID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string PersonName { get; set; }
    }
}
