using PizzaShop.Application.DTOs;
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

        public async Task<IEnumerable<PizzaDto>> GetPizzaAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
