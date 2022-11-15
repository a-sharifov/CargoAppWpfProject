using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp6.ViewModel;
using SimpleInjector;
using GalaSoft.MvvmLight.Messaging;
using WpfApp6.Service.Interface;
using WpfApp6.Service.Classes;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static SimpleInjector.Container ?Container { get; set; }

        protected override void OnStartup(StartupEventArgs e) 
        {
            Register();
            MainStartup();
            base.OnStartup(e);
        }

        private void Register()
        {
            Container = new();

            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigationService, NavigationService>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<SignUpViewModel>();
            Container.RegisterSingleton<SignInViewModel>();
            Container.RegisterSingleton<UserMainViewModel>();
            Container.RegisterSingleton<UserSettingsViewModel>();
            Container.RegisterSingleton<DeclerationViewModel>();
            Container.RegisterSingleton<AdminWindowViewModel>();
            Container.Verify();
        }

        private void MainStartup()
        {
            Window mainView = new MainWindow();

            mainView.DataContext = Container?.GetInstance<MainViewModel>();

            mainView.ShowDialog();
        }
    }
}
