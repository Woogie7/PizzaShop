using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Application.DTOs;
using PizzaShop.Application.Interface;
using PizzaShop.Application.Interface.Repository;
using PizzaShop.Domain.Entities;
using PizzaShop.Persistence.Context;

namespace PizzaShop.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMapper _mapper;

        private readonly PizzaShopDbContextFactory _contextFactory;
        private readonly IAuthenticator _authenticator;

        public OrderRepository(PizzaShopDbContextFactory contextFactory, IMapper mapper, IAuthenticator authenticator)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
            _authenticator = authenticator;
        }

        public async Task IncreaseQuantity(OrderDto orderDto)
        {
            using (PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {
                var order = await context.Orders.FirstOrDefaultAsync(p => p.Id == orderDto.Id && p.UserId == _authenticator.CurrentUser.Id);

                order.Quantity++;

                await context.SaveChangesAsync();
            }
        }

        public async Task DecreaseQuantity(OrderDto orderDto)
        {
            using (PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {
                var order = await context.Orders.FirstOrDefaultAsync(p => p.Id == orderDto.Id && p.UserId == _authenticator.CurrentUser.Id);

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
                    .Where(p => p.UserId == _authenticator.CurrentUser.Id)
                    .ToListAsync();



                var orders = entities.Select(order => _mapper.Map<OrderDto>(order));

                return orders;
            }
        }

        public async Task CreateOrder(OrderDto orderDto)
        {
            using (PizzaShopDBContext context = _contextFactory.CreateDbContext())
            {
                var newOrder = _mapper.Map<Order>(orderDto);

                var pizza = await context.Pizzas.FirstOrDefaultAsync(c => c.Id == newOrder.PizzaId);
                var user = await context.Users.FirstOrDefaultAsync(c => c.Id == _authenticator.CurrentUser.Id);

                newOrder.Pizza = pizza;
                newOrder.User = user;

                var findOrder = await context.Orders.FirstOrDefaultAsync(p => p.PizzaId == newOrder.PizzaId && p.UserId == _authenticator.CurrentUser.Id);
                if (findOrder != null)
                {
                    findOrder.Quantity++;
                }
                else
                {
                    await context.Orders.AddAsync(newOrder);
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
