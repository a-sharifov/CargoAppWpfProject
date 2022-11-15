using ControlzEx.Standard;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Converters;
using Microsoft.Xaml.Behaviors.Core;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp6.Message.Classes;
using WpfApp6.Model;
using WpfApp6.Service.Classes;
using WpfApp6.Service.Interface;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp6.ViewModel
{
    public class SignUpViewModel : ViewModelBase
    {
        public UserPageModel User { get; set; }
        public string? ConfirmText { get; set; }
        public string? ErrorText { get; set; }
        public Admin_UserContentModel? AllUser { get; set; }

        private readonly INavigationService _service;

        public SignUpViewModel(INavigationService service, IMessenger messenger)
        {
            User = new();
            _service = service;
            messenger.Register<ParameterMessage>(this, param => {
                    AllUser = param?.Message as Admin_UserContentModel;
            });
        }

        public RelayCommand MouseClickReturnButton => new(() => { _service.NavigateTo<SignInViewModel>(); });
        public RelayCommand MouseClickRegisterButton => new(() => {
            if ( User.UserName != null && !AllUser.AllUser.ContainsKey(User.UserName))
            {
                if (User.Password == ConfirmText)
                {
                    if (!string.IsNullOrWhiteSpace(User.Password) && !string.IsNullOrWhiteSpace(User.UserName) && !string.IsNullOrWhiteSpace(User.Serial)
                       && !string.IsNullOrWhiteSpace(User.Address) && !string.IsNullOrWhiteSpace(User.Number) && !string.IsNullOrWhiteSpace(User.FIN))
                    {
                        User.Password = MD5HashService.GetHash(ConfirmText);
                        AllUser.AllUser.Add(User.UserName, new UserCargoModel() { User = User });
                        _service.NavigateTo<SignInViewModel>();
                    }
                    else ErrorText = "Entered incorrectly";
                }
                else ErrorText = "Password is incorrect";
            }
            else ErrorText = "Such an account exists";
        });
    }
} 