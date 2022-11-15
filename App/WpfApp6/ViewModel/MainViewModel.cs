using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WpfApp6.Message.Classes;
using WpfApp6.Service.Classes;

namespace WpfApp6.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase? CurrentViewModel { get; set; }
        private readonly IMessenger _messenger;

        public MainViewModel(IMessenger messenger)
        {
            CurrentViewModel = App.Container?.GetInstance<SignInViewModel>();

            _messenger = messenger;

            _messenger.Register<NavigationMessage?>(this, message =>
            {
                var viewModel = App.Container?.GetInstance(message.ViewModelType) as ViewModelBase;
                CurrentViewModel = viewModel;
            });
        }

        public RelayCommand CloseWindow => new(() => {
            UserAccountSaveService.SaveUser(App.Container?.GetInstance<UserMainViewModel>().User);
        });

    }
}

