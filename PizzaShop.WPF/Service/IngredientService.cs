using PizzaShop.Application.DTOs;
using PizzaShop.Application.Interface;
using PizzaShop.Application.Interface.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.Service
{
    internal class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task<IEnumerable<IngredientDto>> GetIngredientAllAsync()
        {
            return await _ingredientRepository.GetAllAsync();
        }
    }
}
