using PizzaShop.Application.DTOs;
using PizzaShop.Application.DTOs.Size;
using PizzaShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Application.Interface.Repository
{
    public interface ISizeRepository
    {
        Task<Size> GetByIdAsync(int id);
        Task<IEnumerable<SizeDto>> GetAllAsync();
        Task<Size> AddAsync(Size entity);
        Task UpdateAsync(Size entity);
        Task DeleteAsync(int id);
        Task DeleteAllAsync();
    }
}
