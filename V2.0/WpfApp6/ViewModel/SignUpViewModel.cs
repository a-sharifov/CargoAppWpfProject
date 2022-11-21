using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using WpfApp6.Model;
using WpfApp6.Service.Classes;
using WpfApp6.Service.Interface;
using static WpfApp6.Model.AdminUserContentModel;

namespace WpfApp6.ViewModel;

public partial class SignUpViewModel : ViewModelBase
{
    public UserPageModel? User { get; set; } = new();
    private readonly INavigationService _service;

    public SignUpViewModel(INavigationService service)
    {
        _service = service;
    }
}

public partial class SignUpViewModel
{
    public RelayCommand MouseClickReturnButton => new(() => { _service.NavigateTo<SignInViewModel>(); });
    public RelayCommand MouseClickRegisterButton => new(() =>
    {
        var errortext = RegexUserService.UserVerification(User!);
        if (errortext == null)
        {
            User!.Password = MD5HashService.GetHash(User!.Password);
            UserInfo.Add(User.UserName!, new UserCargoModel() { User = User });
            _service.NavigateTo<SignInViewModel>();
        }
        else MessageBox.Show(errortext);
    });
} 