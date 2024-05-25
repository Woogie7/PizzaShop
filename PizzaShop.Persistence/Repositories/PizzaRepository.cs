using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Application.DTOs;
using PizzaShop.Application.Interface.Repository;
using PizzaShop.Domain.Entities;
using PizzaShop.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Persistence.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly IMapper _mapper;

        private readonly PizzaShopDbContextFactory _contextFactory;

        public PizzaRepository(PizzaShopDbContextFactory contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }
        public async Task<Pizza> AddAsync(Pizza entity)
        {
            using (PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {
                var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == 1);
                var size = await context.Size.FirstOrDefaultAsync(c => c.Id == 1);
                var ingredients = await context.Ingredients.Take(3).ToListAsync();

                var pizza = new Pizza
                {
                    Id = 1,
                    Category = category,
                    CategoryId = 1,
                    Description = "Описание",
                    Ingredients = ingredients,
                    Name = "Гавайская",
                    Price = 120,
                    Size = size,
                    SizeId = 1
                };

                await context.AddAsync(pizza);
                await context.SaveChangesAsync();

                return pizza;
            }
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PizzaDto>> GetAllAsync()
        {
            using (PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {

                IEnumerable<Pizza> entities = await context.Pizzas
                    .AsNoTracking()
                    .Include(p => p.Ingredients)
                    .Include(p => p.Category)
                    .Include(p => p.Size)
                    .ToListAsync();

                

                var pizzas = entities.Select(income => _mapper.Map<PizzaDto>(income));

                return pizzas;
            }
        }

        public Task<Pizza> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Pizza entity)
        {
            throw new NotImplementedException();
        }
    }
}
