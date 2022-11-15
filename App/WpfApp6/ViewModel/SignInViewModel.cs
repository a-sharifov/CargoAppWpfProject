using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp6.Message.Classes;
using WpfApp6.Model;
using WpfApp6.Service.Classes;
using WpfApp6.Service.Interface;
using WpfApp6.View;

namespace WpfApp6.ViewModel
{
    public class SignInViewModel : ViewModelBase
    {
        public string ErrorText { get; set; }
        public string UsernameText { get; set; }
        public string ColorSignUp { get; set; }
        public Admin_UserContentModel? ContentModel { get; set; }
        private INavigationService? _navigationService;

        public SignInViewModel(INavigationService? navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            ErrorText = "";
            UsernameText = "";
            ColorSignUp = "#FF000000";

            var Save = FileService.ReadAs("Admin.txt");
            ContentModel = SerialiazibleService.Deserialization<Admin_UserContentModel>(Save) ?? new Admin_UserContentModel();

            messenger.Register<ParameterMessage>(this, param => {
                var TmpContentModel = param?.Message as Admin_UserContentModel;
                if (TmpContentModel != null)
                    ContentModel = TmpContentModel;
            });
        }

        public RelayCommand MouseEnterSignUp => new(() => { ColorSignUp = "#FF673AB7"; });
        public RelayCommand MouseLeaveSignUp => new(() => { ColorSignUp = "#FF000000"; });

        public RelayCommand ClickSignUp => new(() => {
            ColorSignUp = "#FF000000";
            _navigationService?.NavigateTo<SignUpViewModel>(new ParameterMessage() {Message = ContentModel });
        });
        public RelayCommand<PasswordBox> SignInCommand => new(password => {
            if (UsernameText == "Admin" && password.Password == "Admin")
            {
                _navigationService?.NavigateTo<AdminWindowViewModel>(new ParameterMessage() { Message = ContentModel });
            }
            else if (ContentModel != null && ContentModel.AllUser.ContainsKey(UsernameText))
            {
                if (ContentModel?.AllUser?[UsernameText]?.User?.Password == MD5HashService.GetHash(password.Password))
                    _navigationService?.NavigateTo<UserMainViewModel>(new ParameterMessage() { Message = ContentModel?.AllUser[UsernameText] });
                else ErrorText = "Wrong password";
            }
            else ErrorText = "Not found";
        });
        public RelayCommand ClickExit => new(() => { UserAccountSaveService.SaveUser(); });

    }
}
