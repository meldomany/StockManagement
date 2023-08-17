using Microsoft.EntityFrameworkCore;
using StockManagement.Models;

namespace StockManagement.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Order>()
        //        .HasKey(o => new { o.StockID, o.Price, o.Quantity, o.PersonName });
        //}
    }
}
