using PizzaShop.WPF.Core;
using PizzaShop.WPF.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.Command
{
    internal class DeleteIngredientCommand : BaseCommand
    {
        private readonly ManagePizzaViewModel _managePizzaViewModel;

        public DeleteIngredientCommand(ManagePizzaViewModel managePizzaViewModel)
        {
            _managePizzaViewModel = managePizzaViewModel;
            _managePizzaViewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(_managePizzaViewModel.SelectedIngredient))
                {
                    OnCanExecuteChanged();
                }
            };
        }

        public override bool CanExecute(object parameter)
        {
            var ass = _managePizzaViewModel.SelectedIngredient != null &&
                   _managePizzaViewModel.PizzaIngredients.Contains(_managePizzaViewModel.SelectedIngredient) &&
                   base.CanExecute(parameter);

            return ass;
        }

        public override void Execute(object parameter)
        {
            _managePizzaViewModel.PizzaIngredients.Remove(_managePizzaViewModel.SelectedIngredient);
        }
    }
}
