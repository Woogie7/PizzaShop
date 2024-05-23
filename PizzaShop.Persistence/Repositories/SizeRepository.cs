using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Application.DTOs;
using PizzaShop.Application.DTOs.Size;
using PizzaShop.Application.Interface;
using PizzaShop.Domain.Entities;
using PizzaShop.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Persistence.Repositories
{
    public class SizeRepository : ISizeRepository
    {
        private readonly IMapper _mapper;

        private readonly PizzaShopDbContextFactory _contextFactory;
        public SizeRepository(IMapper mapper, PizzaShopDbContextFactory contextFactory)
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

        public async Task<IEnumerable<SizeDto>> GetAllAsync()
        {
            using (PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {

                IEnumerable<Size> entities = await context.Size
                    .AsNoTracking()
                    .ToListAsync();



                var sizes = entities.Select(size => _mapper.Map<SizeDto>(size));

                return sizes;
            }
        }

        public Task<Size> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Size entity)
        {
            throw new NotImplementedException();
        }
    }
}
