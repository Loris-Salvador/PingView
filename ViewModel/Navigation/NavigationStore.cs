using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Navigation
{
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;
        private IDialogService _dialogService;

        public NavigationStore(IDialogService dialogService) { _dialogService = dialogService; }
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public IDialogService DialogService
        {
            get { return _dialogService; }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;

    }
}
