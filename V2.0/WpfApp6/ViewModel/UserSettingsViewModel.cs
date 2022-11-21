using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using WpfApp6.Message.Classes;
using WpfApp6.Model;
using WpfApp6.Service.Classes;
using WpfApp6.Service.Interface;

namespace WpfApp6.ViewModel;
public partial class UserSettingsViewModel : ViewModelBase
{
    public UserCargoModel? User { get; set; }
    public string? PasswordText { get; set; }
    private readonly INavigationService _service;

    public UserSettingsViewModel(INavigationService service, IMessenger messenger)
    {
        _service = service;
        messenger.Register<ParameterMessage>(this, param =>
        {
            User = param?.Message as UserCargoModel;
        });
    }
}
public partial class UserSettingsViewModel 
{
    public RelayCommand SaveSettings => new(() =>
    {
        var errortext = RegexUserService.UserVerification(User!.User!);
        if (errortext == null)
        {
            if (!string.IsNullOrWhiteSpace(PasswordText))
                User.User!.Password = MD5HashService.GetHash(PasswordText);
            _service?.NavigateTo<UserMainViewModel>(new ParameterMessage { Message = User });
        }
        else MessageBox.Show(errortext);
    });
} 