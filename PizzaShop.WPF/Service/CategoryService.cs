using PizzaShop.Application.DTOs.Size;
using PizzaShop.Application.Interface.Repository;
using PizzaShop.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaShop.Application.DTOs;

namespace PizzaShop.WPF.Service
{
    internal class CategoryService : ICategorySevice
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoryAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
