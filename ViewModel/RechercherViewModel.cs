using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.Command;
using ViewModel.Navigation;

namespace ViewModel
{
    public class RechercherViewModel : ViewModelBase
    {


        public ICommand HomeCommand { get; }
        public RechercherViewModel(NavigationStore navigationStore)
        {
           HomeCommand = new HomeCommand(navigationStore);
        }
    }
}
