using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Navigation;
using ViewModel;

namespace View
{
    public class DialogService : IDialogService
    {
        private ParametreWindow _window;
        public void ShowDialog()
        {
            _window = new ParametreWindow()
            {
                DataContext = new ParametreViewModel()
            };

            _window.ShowDialog();
        }
    }
}
