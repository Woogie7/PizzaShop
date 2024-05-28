using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Application.DTOs.Pizza;
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
        public async Task<CreatePizzaDto> AddAsync(CreatePizzaDto newPizzaDto)
        {
            using (PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {

                var pizza = _mapper.Map<Pizza>(newPizzaDto);


                var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == newPizzaDto.CategoryId);
                var size = await context.Size.FirstOrDefaultAsync(c => c.Id == newPizzaDto.SizeId);
                var ingredients = await context.Ingredients
                                    .Where(i => newPizzaDto.IngredientsId.Contains(i.Id))
                                    .ToListAsync();

                pizza.Category = category;
                pizza.Size = size;
                pizza.Ingredients = ingredients;
                pizza.ImagePath = "dsa";

                await context.AddAsync(pizza);
                await context.SaveChangesAsync();

                return newPizzaDto;
            }
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(PizzaDto pizzaDto)
        {
            using (PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {
                var deletedPizza = await context.Pizzas.FirstOrDefaultAsync(p => p.Name == pizzaDto.Name);

                context.Pizzas.Remove(deletedPizza);
                await context.SaveChangesAsync();
            }
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
