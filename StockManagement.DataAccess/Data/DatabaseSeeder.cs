using StockManagement.Models;

namespace StockManagement.DataAccess.Data
{
    public static class DatabaseSeeder
    {
        public static void SeedData(ApplicationDbContext context)
        {
            // Check if the database is already seeded
            if (!context.Stocks.Any())
            {
                Random random = new Random();

                var stocks = new List<Stock>
                {
                    new Stock { Name = "Vianet", Price = random.Next(1, 101) },
                    new Stock { Name = "Agritek", Price = random.Next(1, 101) },
                    new Stock { Name = "Akamai", Price = random.Next(1, 101) },
                    new Stock { Name = "Baidu", Price = random.Next(1, 101) },
                    new Stock { Name = "Blinkx", Price = random.Next(1, 101) },
                    new Stock { Name = "Blucora", Price = random.Next(1, 101) },
                    new Stock { Name = "Boingo", Price = random.Next(1, 101) },
                    new Stock { Name = "Brainybrawn", Price = random.Next(1, 101) },
                    new Stock { Name = "Carbonite", Price = random.Next(1, 101) },
                    new Stock { Name = "China Finance", Price = random.Next(1, 101) },
                    new Stock { Name = "ChinaCache", Price = random.Next(1, 101) },
                    new Stock { Name = "ADR", Price = random.Next(1, 101) },
                    new Stock { Name = "ChitrChatr", Price = random.Next(1, 101) },
                    new Stock { Name = "Cnova", Price = random.Next(1, 101) },
                    new Stock { Name = "Cogent", Price = random.Next(1, 101) },
                    new Stock { Name = "Crexendo", Price = random.Next(1, 101) },
                    new Stock { Name = "CrowdGather", Price = random.Next(1, 101) },
                    new Stock { Name = "EarthLink", Price = random.Next(1, 101) },
                    new Stock { Name = "Eastern", Price = random.Next(1, 101) },
                    new Stock { Name = "ENDEXX", Price = random.Next(1, 101) },
                    new Stock { Name = "Envestnet", Price = random.Next(1, 101) },
                    new Stock { Name = "Epazz", Price = random.Next(1, 101) },
                    new Stock { Name = "FlashZero", Price = random.Next(1, 101) },
                    new Stock { Name = "Genesis", Price = random.Next(1, 101) },
                    new Stock { Name = "InterNAP", Price = random.Next(1, 101) },
                    new Stock { Name = "MeetMe", Price = random.Next(1, 101) },
                    new Stock { Name = "Netease", Price = random.Next(1, 101) },
                    new Stock { Name = "Qihoo", Price = random.Next(1, 101) }
                };

                context.Stocks.AddRange(stocks);
                context.SaveChanges();
            }
        }
    }
}
