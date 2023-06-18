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
        private string _newIndew = "";

        public string NewIndex
        {
            get { return _newIndew; }
            set
            {
                if (value == "") return;
                _newIndew = value;
            }
        }
        private string _pathFichier = "";
        public string PathFichier
        {
            get { return _pathFichier; }
            set { 
                if (value == "") return;
                _pathFichier = value;
            }
        }

        private bool _isMessageVisible = false;
        public bool IsMessageVisible
        {
            get { return _isMessageVisible; }

            set
            {
                if (value == _isMessageVisible) return;
                _isMessageVisible = value;
                OnPropertyChanged();
            }
        }
        public ICommand AppliquerCommand { get; }
        public ParametreViewModel()
        {
            AppliquerCommand = new AppliquerCommand(this);
        }
    }
}
