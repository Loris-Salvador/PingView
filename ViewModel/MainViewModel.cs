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

        //private int _width = 800;

        //public int Width
        //{
        //    get { return _width; }
        //    set
        //    {
        //        if (value == _width) return;
        //        if (value < 600)
        //        {
        //            _navigationStore.CurrentViewModel.ChangeWindow();
        //        }
        //        _width = value;
        //        OnPropertyChanged();
        //    }
        //}

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

        public int DimensionX
        {
            get => MyRegistryParam.DimensionX;
            set
            {
                if (MyRegistryParam.DimensionX != value)
                {
                    MyRegistryParam.DimensionX = value;
                    OnPropertyChanged(nameof(DimensionX));
                }
            }
        }

        public int DimensionY
        {
            get => MyRegistryParam.DimensionY;
            set
            {
                if (MyRegistryParam.DimensionY != value)
                {
                    MyRegistryParam.DimensionY = value;
                    OnPropertyChanged(nameof(DimensionY));
                }
            }
        }

        public MainViewModel(NavigationStore navigationStore)
        {
            PositionX = MyRegistryParam.PositionX;
            PositionY = MyRegistryParam.PositionY;
            DimensionX = MyRegistryParam.DimensionX;
            DimensionY = MyRegistryParam.DimensionY;
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }


    }
}
