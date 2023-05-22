using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Navigation;

namespace ViewModel.Command
{
    public class RechercherCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public RechercherCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            Console.WriteLine("Rechercher Pressed");
            _navigationStore.CurrentViewModel = new RechercherViewModel();
        }
    }
}

