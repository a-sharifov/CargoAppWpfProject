using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using WpfApp6.Message.Classes;
using WpfApp6.Service.Interface;

namespace WpfApp6.Service.Classes;
public class NavigationService : INavigationService
{
    private readonly IMessenger _messenger;
    public NavigationService(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void NavigateTo<T>(ParameterMessage? message) where T : ViewModelBase
    {
        _messenger.Send(message);
        _messenger.Send(new NavigationMessage() { ViewModelType = typeof(T) });
    }
}
