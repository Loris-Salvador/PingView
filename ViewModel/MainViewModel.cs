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

       

        public bool Maximised
        {
            get => MyRegistryParam.Maximised;
            set
            {
                if (MyRegistryParam.Maximised != value)
                {
                    MyRegistryParam.Maximised = value;
                    OnPropertyChanged(nameof(Maximised));
                }
            }
        }

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
/*                if (MyRegistryParam.DimensionX != value)
                {*/
                    if (DimensionX < 900 && _navigationStore.CurrentViewModel.GetType().ToString() == "ViewModel.PlayerViewModel")
                    {
                        PlayerViewModel playerViewModel = (PlayerViewModel)CurrentViewModel;
                        playerViewModel.IsGridMatchesVisible = false; // envisager de le faire dans le viewModel base
                    }
                    else if (DimensionX > 900 && _navigationStore.CurrentViewModel.GetType().ToString() == "ViewModel.PlayerViewModel")
                    {
                        PlayerViewModel playerViewModel = (PlayerViewModel)CurrentViewModel;
                        playerViewModel.IsGridMatchesVisible = true;
                    }
                    MyRegistryParam.DimensionX = value;
                    OnPropertyChanged(nameof(DimensionX));
                //}
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
            _navigationStore = navigationStore;
            PositionX = MyRegistryParam.PositionX;
            PositionY = MyRegistryParam.PositionY;
            DimensionX = MyRegistryParam.DimensionX;
            DimensionY = MyRegistryParam.DimensionY;
            Maximised = MyRegistryParam.Maximised;
            Console.WriteLine("Type" + _navigationStore.CurrentViewModel.GetType().ToString());
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }


    }
}
