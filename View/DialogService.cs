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
        public void ShowDialog()
        {
            var dialog = new ParametreWindow()
            {
                DataContext = new ParametreViewModel()
            };

            dialog.ShowDialog();
        }
    }
}
