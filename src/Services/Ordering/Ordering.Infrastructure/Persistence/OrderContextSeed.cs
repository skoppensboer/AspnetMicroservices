using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext context, ILogger<OrderContextSeed> logger)
        {
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(GetPreconfiguredOrders());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database asscociated ");
            }
        }

        public static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() { UserName = "sjs", FirstName = "Skip", LastName = "Scheepers", EmailAddress = "skip@abc.com", TotalPrice = 350.00M }
            };
        }
    }
}
