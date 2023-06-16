using Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;
using Model;
using ViewModel.Navigation;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore = new NavigationStore(new DialogService());
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new PlayerViewModel(_navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            
            Console.WriteLine(MainWindow.Top.ToString());

            base.OnStartup(e);

            Application.Current.Exit += Application_Exit;
        }


        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            _navigationStore.CurrentViewModel.Dispose();
        }
    }
}
