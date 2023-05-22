using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Navigation;

namespace ViewModel.Command
{
    public class HomeCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public HomeCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            Console.WriteLine("Home Pressed");
            _navigationStore.CurrentViewModel = new PlayerViewModel(_navigationStore);
        }
    }
}
