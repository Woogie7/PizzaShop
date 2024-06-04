using PizzaShop.Application.DTOs.Pizza;

namespace PizzaShop.Application.Interface
{
    public interface IPizzaService
    {
        Task<IEnumerable<PizzaDto>> GetPizzaAllAsync();
        Task<CreatePizzaDto> AddPizzaAsync(CreatePizzaDto newPizza);
        Task UpdatePizzaAsync(UpdatePizzaDto updatedPizza);
        Task DeletePizzaAsync(PizzaDto pizzaDto);
    }
}
