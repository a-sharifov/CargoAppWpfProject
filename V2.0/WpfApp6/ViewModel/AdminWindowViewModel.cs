using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using WpfApp6.Model;
using WpfApp6.Service.Classes;
using WpfApp6.Service.Interface;
using static WpfApp6.Model.AdminUserContentModel;

namespace WpfApp6.ViewModel;
public partial class AdminWindowViewModel : ViewModelBase
{
    public string? SearchConfirm { get; set; }
    public string? Search { get; set; }
    public PreparationDeclerationModel? Selected { get; set; }
    public ObservableCollection<PreparationDeclerationModel>? Preparation { get; set; }
    private readonly INavigationService _service;

    public AdminWindowViewModel(INavigationService navigationService)
    {
        _service = navigationService;
    }
}

public partial class AdminWindowViewModel
{
    public RelayCommand SearchCommand => new(() =>
    {
        if (UserInfo!.ContainsKey(Search!))
        {
            SearchConfirm = Search;
            Preparation = new(UserInfo[SearchConfirm!]!.UserOrder!);
        }
    });

    public RelayCommand ReturnCommand => new(() =>
    {
        _service.NavigateTo<SignInViewModel>();
    });

    public RelayCommand DeleteDeclerationCommand => new(() =>
    {
        if (RegexUserService.SuchAUser(Search) && Search == SearchConfirm) 
        {
            UserInfo[SearchConfirm!].Remove(Selected!);
            Preparation = new(UserInfo[SearchConfirm!].UserOrder!);
        }
    });
}
