using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace StockManagement.DataAccess.Data
{
    public class DataSeedProcess: IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DataSeedProcess(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                // Call your seeding method
                DatabaseSeeder.SeedData(dbContext);
            }

            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
