using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel.Command
{
    public class AppliquerCommand : CommandBase
    {
        private ParametreViewModel _viewModel;
        public AppliquerCommand(ParametreViewModel vm) { _viewModel = vm; }
        public override void Execute(object parameter)
        {
            MyData.getInstance().Index =  _viewModel.NewIndex;
        }
    }
}
