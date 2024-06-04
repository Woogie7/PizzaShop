using PizzaShop.Application.DTOs.Pizza;
using PizzaShop.Application.Interface;
using PizzaShop.Application.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.Service
{
    internal class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _repository;

        public PizzaService(IPizzaRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreatePizzaDto> AddPizzaAsync(CreatePizzaDto newPizza)
        {
            return await _repository.AddAsync(newPizza);
        }

        public async Task DeletePizzaAsync(PizzaDto pizzaDto)
        {
            await _repository.DeleteAsync(pizzaDto);
        }

        public async Task<IEnumerable<PizzaDto>> GetPizzaAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task UpdatePizzaAsync(UpdatePizzaDto updatedPizza)
        {
            await _repository.UpdateAsync(updatedPizza);
        }
    }
}
