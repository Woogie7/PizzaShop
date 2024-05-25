using PizzaShop.WPF.Core;
using PizzaShop.WPF.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.Command
{
    internal class AddIngredientCommand : BaseCommand
{
    private readonly ManagePizzaViewModel _managePizzaViewModel;

    public AddIngredientCommand(ManagePizzaViewModel managePizzaViewModel)
    {
        _managePizzaViewModel = managePizzaViewModel;
    }

    public override bool CanExecute(object parameter)
    {
        return _managePizzaViewModel.SelectedIngredient != null &&
               !_managePizzaViewModel.PizzaIngredients.Contains(_managePizzaViewModel.SelectedIngredient) && 
               base.CanExecute(parameter);
    }

    public override void Execute(object parameter)
    {
        _managePizzaViewModel.PizzaIngredients.Add(_managePizzaViewModel.SelectedIngredient);
    }
}

}
