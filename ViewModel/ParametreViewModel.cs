using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FonctionUtil;
using Infrastructure;
using ViewModel.Command;

namespace ViewModel
{
    public class ParametreViewModel : ViewModelBase
    {
        public string NewIndex { get; set; }
        public ICommand AppliquerCommand { get; }
        public ParametreViewModel()
        {
            AppliquerCommand = new AppliquerCommand(this);
        }
        

    }
}
