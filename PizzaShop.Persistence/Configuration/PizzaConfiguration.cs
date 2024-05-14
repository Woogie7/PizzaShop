using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Persistence.Configuration
{
    public class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Size)
                   .WithMany(p => p.Pizzas)
                   .HasForeignKey(p => p.SizeId)
                   .IsRequired();

            builder.HasOne(p => p.Category)
                   .WithMany()
                   .HasForeignKey(p => p.CategoryId)
                   .IsRequired();

            builder.HasMany(p => p.Ingredients)
                   .WithMany(p => p.Pizzas)
                   .UsingEntity<PizzaIngredients>(
                        i => i.HasOne<Ingredient>().WithMany().HasForeignKey(i => i.IngredientId),
                        p => p.HasOne<Pizza>().WithMany().HasForeignKey(p => p.PizzaId));
        }
    }
}
