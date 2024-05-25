using PizzaShop.Application.DTOs;
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
        Task<Pizza> AddAsync(Pizza entity);
        Task UpdateAsync(Pizza entity);
        Task DeleteAsync(int id);
        Task DeleteAllAsync();
    }
}
