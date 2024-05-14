using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Persistence.Configuration
{
    internal class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(s => s.Id);

            var ingredients = Enum
                .GetValues<IngredientEnum>()
                .Select(r => new Ingredient
                {
                    Id = (int)r,
                    Name = r.ToString()
                });

            builder.HasData(ingredients);
        }
    }
}
