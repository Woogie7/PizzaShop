using Microsoft.EntityFrameworkCore;
using PizzaShop.Domain.Entities;
using PizzaShop.Persistence.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Persistence.Context;

public class PizzaShopDBContext : DbContext
{
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Ingredient> Ingredients{ get; set; }
    public DbSet<Order> Orders{ get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Size> Size { get; set; }

    public DbSet<Role> Roles { get; set; }

    public PizzaShopDBContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PizzaConfiguration());
        modelBuilder.ApplyConfiguration(new SizeConfiguration());
        modelBuilder.ApplyConfiguration(new IngredientConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
}