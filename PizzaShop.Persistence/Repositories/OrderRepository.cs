using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Application.DTOs;
using PizzaShop.Application.DTOs.Pizza;
using PizzaShop.Application.DTOs.User;
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

        public async Task IncreaseQuantity(OrderDto orderDto)
        {
            using (PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {
                var order = await context.Orders.FirstOrDefaultAsync(p => p.Id == orderDto.Id);

                order.Quantity++;

                await context.SaveChangesAsync();
            }
        }

        public async Task DecreaseQuantity(OrderDto orderDto)
        {
            using (PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {
                var order = await context.Orders.FirstOrDefaultAsync(p => p.Id == orderDto.Id);

                order.Quantity--;

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            using (PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {

                IEnumerable<Order> entities = await context.Orders
                    .AsNoTracking()
                    .Include(p => p.Pizza)
                    .Include(p => p.User)
                    .ToListAsync();



                var orders = entities.Select(order => _mapper.Map<OrderDto>(order));

                return orders;
            }
        }

        public async Task CreateOrder(OrderDto orderDto)
        {
            using (PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {
                var order = _mapper.Map<Order>(orderDto);

                var pizza = await context.Pizzas.FirstOrDefaultAsync(c => c.Id == order.PizzaId);
                var user = await context.Users.FirstOrDefaultAsync(c => c.Id == order.UserId);

                order.Pizza = pizza;
                order.User = user;

                var findOrder = await context.Orders.FirstOrDefaultAsync(p => p.PizzaId == order.PizzaId);
                if(findOrder != null)
                {
                    findOrder.Quantity++;
                }
                else
                {
                    await context.Orders.AddAsync(order);
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteOrder(OrderDto orderDto)
        {
            using (PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {
                var order = _mapper.Map<Order>(orderDto);

                var pizza = await context.Pizzas.FirstOrDefaultAsync(c => c.Id == order.PizzaId);
                var user = await context.Users.FirstOrDefaultAsync(c => c.Id == order.UserId);

                order.Pizza = pizza;
                order.User = user;

                context.Orders.Remove(order);
                await context.SaveChangesAsync();
            }
        }
    }
}
