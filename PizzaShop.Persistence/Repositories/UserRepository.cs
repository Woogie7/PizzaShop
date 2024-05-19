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
    public class UserRepository : IUserRepository
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

                var newUser = new User
                {
                    Id = Guid.NewGuid(),
                    Email = user.Email,
                    PasswordHash = user.PasswordHash,
                    Role = role,
                    UserName = user.UserName,
                    RoleId = role.Id
                };

                await context.AddAsync(newUser);
                await context.SaveChangesAsync();
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            using(PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {
                var user = await context.Users
                        .AsNoTracking()
                        .FirstOrDefaultAsync(user => user.Email == email);

                return user;
            }
        }
    }
}
