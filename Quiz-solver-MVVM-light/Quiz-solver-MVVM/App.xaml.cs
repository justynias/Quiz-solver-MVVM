using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Quiz_solver_MVVM.Helpers;
using Quiz_solver_MVVM.ViewModel;

namespace Quiz_solver_MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IFrameNavigationService navigationService = new FrameNavigationService();
            MainWindow app = new MainWindow();
            MainViewModel context = new MainViewModel(navigationService);
            app.DataContext = context;
            app.Show();
        }
    }
}
