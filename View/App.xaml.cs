﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;
using ViewModel.Navigation;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore = new NavigationStore();
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new PlayerViewModel(_navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }


        protected override void OnExit(ExitEventArgs e)
        {
            //REGISTRY
            base.OnExit(e);
        }
    }
}
