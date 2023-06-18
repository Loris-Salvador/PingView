using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using FonctionUtil;

namespace ViewModel.Command
{
    public class AppliquerCommand : CommandBase
    {
        private ParametreViewModel _viewModel;
        public AppliquerCommand(ParametreViewModel vm) { _viewModel = vm; }
        public override void Execute(object parameter)
        {
            if(_viewModel.NewIndex != "")
            {
                MyData.getInstance().Index = _viewModel.NewIndex;
                MyData.getInstance().Reload = true;
            }
            if(_viewModel.PathFichier != "")
                MyRegistryParam.Path = _viewModel.PathFichier;

            _viewModel.IsMessageVisible = true;
        }
    }
}
