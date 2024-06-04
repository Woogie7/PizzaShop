using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Application.DTOs.Pizza;
using PizzaShop.Application.Interface.Repository;
using PizzaShop.Domain.Entities;
using PizzaShop.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

        public async Task UpdateAsync(UpdatePizzaDto pizzaDto)
        {
            using (PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {
                var updatedPizza = await context.Pizzas.FirstOrDefaultAsync(p => p.Id == pizzaDto.Id);

                var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == pizzaDto.CategoryId);
                var size = await context.Size.FirstOrDefaultAsync(c => c.Id == pizzaDto.SizeId);
                var ingredients = await context.Ingredients
                                    .Where(i => pizzaDto.IngredientsId.Contains(i.Id))
                                    .ToListAsync();

                updatedPizza.Size = size;
                updatedPizza.SizeId = pizzaDto.SizeId;
                updatedPizza.Category = category;
                updatedPizza.CategoryId = pizzaDto.CategoryId;
                updatedPizza.Name = pizzaDto.Name;
                updatedPizza.Description = pizzaDto.Description;
                updatedPizza.Price = pizzaDto.Price;

                updatedPizza.Ingredients.Clear();

                // Add new ingredients
                foreach (var ingredient in ingredients)
                {
                    updatedPizza.Ingredients.Add(ingredient);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
