using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Persistence.Context
{
    internal class PizzaShopDbContextFactory : IDesignTimeDbContextFactory<PizzaShopDBContext>
    {
        public PizzaShopDBContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<PizzaShopDBContext>();
            options.UseNpgsql("Server=(localdb)\\MSSQLLocalDB;Database=SimpleTraderDB;Trusted_Connection=True;");

            return new SimpleTraderDbContext(options.Options);
        }
    }
}
