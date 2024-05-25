using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Application.DTOs;
using PizzaShop.Application.Interface.Repository;
using PizzaShop.Domain.Entities;
using PizzaShop.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Persistence.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly IMapper _mapper;

        private readonly PizzaShopDbContextFactory _contextFactory;
        public IngredientRepository(IMapper mapper, PizzaShopDbContextFactory contextFactory)
        {
            _mapper = mapper;
            _contextFactory = contextFactory;
        }
        public Task<Size> AddAsync(Size entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IngredientDto>> GetAllAsync()
        {
            using (PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Ingredient> entities = await context.Ingredients
                    .AsNoTracking()
                    .ToListAsync();

                var ingredients = entities.Select(ingredient => _mapper.Map<IngredientDto>(ingredient));

                return ingredients;
            }
        }

        public Task<Ingredient> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Size entity)
        {
            throw new NotImplementedException();
        }
    }
}
