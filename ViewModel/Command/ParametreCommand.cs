using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Navigation;

namespace ViewModel.Command
{
    public class ParametreCommand : CommandBase
    {
        private NavigationStore _navigationStore;
        public ParametreCommand(NavigationStore navigationStore) { _navigationStore = navigationStore; }
        public override void Execute(object parameter)
        {
            _navigationStore.DialogService.ShowDialog();
        }
    }
}
