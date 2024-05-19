using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PizzaShop.Application.DTOs.User;
using PizzaShop.Application.Interface;
using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Enum;
using PizzaShop.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Persistence.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;

        private readonly PizzaShopDbContextFactory _contextFactory;

        public UserRepository(PizzaShopDbContextFactory contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }
        public async Task Add(CreateUserDto user)
        {
            using (PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {
                var role = await context.Roles.FirstOrDefaultAsync(r => r.Id == (int)RoleEnum.Admin);
            }
        }

        public Task<User> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
