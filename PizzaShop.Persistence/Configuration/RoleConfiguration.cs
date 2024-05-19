using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Persistence.Configuration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(u => u.Id);

            var roles = Enum
                .GetValues<RoleEnum>()
                .Select(r => new Role
                {
                    Id = (int)r,
                    Name = r.ToString()
                });

            builder.HasData(roles);
        }
    }
}
