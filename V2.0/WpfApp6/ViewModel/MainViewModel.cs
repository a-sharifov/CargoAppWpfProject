using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WpfApp6.Message.Classes;
using WpfApp6.Service.Classes;

namespace WpfApp6.ViewModel;

public partial class MainViewModel : ViewModelBase
{
    public ViewModelBase? CurrentViewModel { get; set; } = App.Container?.GetInstance<SignInViewModel>();

    public MainViewModel(IMessenger messenger)
    {
        messenger.Register<NavigationMessage?>(this, message =>
        {
            var viewModel = App.Container?.GetInstance(message!.ViewModelType!) as ViewModelBase;
            CurrentViewModel = viewModel;
        });
    }
}
public partial class MainViewModel 
{
    public RelayCommand CloseWindow => new(() =>
    {
        UserAccountSaveService.SaveUser(App.Container?.GetInstance<UserMainViewModel>().User!);
    });
}