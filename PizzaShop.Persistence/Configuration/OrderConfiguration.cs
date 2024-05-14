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
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasOne(O => O.Pizza)
                .WithMany()
                .HasForeignKey(o => o.PizzaId);
            
            builder.HasOne(o => o.User)
                   .WithMany()
                   .HasForeignKey(o => o.UserId);
        }
    }
}
