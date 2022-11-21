using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Controls;
using WpfApp6.Message.Classes;
using WpfApp6.Service.Classes;
using WpfApp6.Service.Interface;
using static WpfApp6.Model.AdminUserContentModel;

namespace WpfApp6.ViewModel;
public partial class SignInViewModel : ViewModelBase
{
    public string? UsernameText { get; set; }
    private readonly INavigationService? _service;

    public SignInViewModel(INavigationService? navigationService)
    {
        _service = navigationService;
    }
}

public partial class SignInViewModel
{
    public RelayCommand ClickSignUp => new(() =>
    {
        _service?.NavigateTo<SignUpViewModel>(new ParameterMessage());
    });
    public RelayCommand<PasswordBox> SignInCommand => new(password =>
    {
        if (UsernameText == "Admin" && password.Password == "Admin")
        {
            _service?.NavigateTo<AdminWindowViewModel>(new ParameterMessage());
        }
        else if (!RegexUserService.SuchAUser(UsernameText))
        {
            if (UserInfo[UsernameText!].User!.Password == MD5HashService.GetHash(password.Password))
                _service!.NavigateTo<UserMainViewModel>(new ParameterMessage() { Message = UserInfo[UsernameText!] });
            else MessageBox.Show("Password");
        }
        else MessageBox.Show("Not found");
    });
    public RelayCommand ClickExit => new(() => { UserAccountSaveService.SaveUser(); });
}