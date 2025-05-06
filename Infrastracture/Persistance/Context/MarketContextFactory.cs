using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistance.Context;

namespace Persistance.Context
{
    public class MarketContextFactory : IDesignTimeDbContextFactory<MarketContext>
    {
        public MarketContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MarketContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MarketDb;Integrated Security=true;");

            return new MarketContext(optionsBuilder.Options);
        }
    }
}
