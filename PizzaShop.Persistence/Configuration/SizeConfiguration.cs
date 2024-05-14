using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Enum;
using System.Reflection.Emit;
using System.Security;

namespace PizzaShop.Persistence.Configuration
{
    internal class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(s => s.Id);

            var sizes = Enum
                .GetValues<SizeEnum>()
                .Select(r => new Size
                {
                    Id = (int)r,
                    Name = r.ToString()
                });

            builder.HasData(sizes);
        }
    }
}
