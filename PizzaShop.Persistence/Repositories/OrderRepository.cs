using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Application.DTOs;
using PizzaShop.Application.DTOs.Pizza;
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
    public class OrderRepository : IOrderRepository
    {
        private readonly IMapper _mapper;

        private readonly PizzaShopDbContextFactory _contextFactory;

        public OrderRepository(PizzaShopDbContextFactory contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            using (PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {
                var pizza = await context.Pizzas.FirstOrDefaultAsync(p => p.Id == 1);
                var user = await context.Users.FirstOrDefaultAsync(p => p.Role.Name == "Admin");

                var order = new Order()
                {
                    OrderNumber = "214",
                    Pizza = pizza,
                    PizzaId = pizza.Id,
                    Quantity = 2,
                    User = user,
                    UserId = user.Id
                };

                await context.Orders.AddAsync(order);
                await context.SaveChangesAsync();



                IEnumerable<Order> entities = await context.Orders
                    .AsNoTracking()
                    .Include(p => p.Pizza)
                    .Include(p => p.User)
                    .ToListAsync();



                var orders = entities.Select(order => _mapper.Map<OrderDto>(order));

                return orders;
            }
        }
    }
}
