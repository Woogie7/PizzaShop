using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Persistence.Context
{
    public class PizzaShopDbContextFactory : IDesignTimeDbContextFactory<PizzaShopDBContext>
    {
        public PizzaShopDBContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<PizzaShopDBContext>();
            options.UseNpgsql("Host=localhost; Port=5432; Database=PizzaShop; Username=postgres; Password=1234");

            return new PizzaShopDBContext(options.Options);
        }
    }
}
