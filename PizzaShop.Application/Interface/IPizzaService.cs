using PizzaShop.Application.DTOs;

namespace PizzaShop.Application.Interface
{
    public interface IPizzaService
    {
        Task<IEnumerable<PizzaDto>> GetPizzaAllAsync();
    }
}
