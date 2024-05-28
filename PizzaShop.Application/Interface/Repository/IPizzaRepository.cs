using PizzaShop.Application.DTOs.Pizza;
using PizzaShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Application.Interface.Repository
{
    public interface IPizzaRepository
    {
        Task<Pizza> GetByIdAsync(int id);
        Task<IEnumerable<PizzaDto>> GetAllAsync();
        Task<CreatePizzaDto> AddAsync(CreatePizzaDto newPizza);
        Task UpdateAsync(Pizza entity);
        Task DeleteAsync(PizzaDto pizzaDto);
        Task DeleteAllAsync();
    }
}
