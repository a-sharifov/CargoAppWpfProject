using GalaSoft.MvvmLight;
using WpfApp6.Message.Classes;

namespace WpfApp6.Service.Interface;
public interface INavigationService
{
    public void NavigateTo<T>(ParameterMessage? message = null) where T : ViewModelBase;
}