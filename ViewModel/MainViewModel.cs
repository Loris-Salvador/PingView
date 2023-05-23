using Infrastructure;
using ViewModel.Navigation;
using FonctionUtil;
using System;

namespace ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public int PositionX
        {
            get => MyRegistryParam.PositionX;
            set
            {
                if (MyRegistryParam.PositionX != value)
                {
                    MyRegistryParam.PositionX = value;
                    OnPropertyChanged(nameof(PositionX));
                }
            }
        }
        public int PositionY
        {
            get => MyRegistryParam.PositionY;
            set
            {
                if (MyRegistryParam.PositionY != value)
                {
                    MyRegistryParam.PositionY = value;
                    OnPropertyChanged(nameof(PositionY));
                }
            }
        }

        public MainViewModel(NavigationStore navigationStore)
        {
            PositionX = MyRegistryParam.PositionX;
            PositionY = MyRegistryParam.PositionY;
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }


    }
}
