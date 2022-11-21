using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using WpfApp6.Message.Classes;
using WpfApp6.Model;
using WpfApp6.Service.Classes;
using WpfApp6.Service.Interface;

namespace WpfApp6.ViewModel;

public partial class DeclerationViewModel : ViewModelBase
{
    public PreparationDeclerationModel Decleration { get; set; } = new();
    public UserCargoModel? User { get; set; }
    public BitmapImage? ProductImage { get; set; }
    private readonly INavigationService? _service;

    public DeclerationViewModel(INavigationService? navigationService, IMessenger messenger)
    {
        _service = navigationService;
        messenger.Register<ParameterMessage>(this, param =>
        {
            Decleration = new();
            User = param?.Message as UserCargoModel;
        });
    }
}
public partial class DeclerationViewModel
{
    public RelayCommand ClickReturn => new(() => { _service?.NavigateTo<UserMainViewModel>(new ParameterMessage { Message = User }); });
    public RelayCommand ImageDownoload => new(() =>
    {
        OpenFileDialog openImage = new();
        openImage.Filter = "Image files(*.PNG, *.JPG, *.BMP)|*.png;*.jpg;*.bmp";
        if (openImage.ShowDialog() == true)
        {
            Decleration.ProductImage = new Uri(openImage.FileName);
            ProductImage = new(Decleration.ProductImage);
        }
    });
    public RelayCommand ClickSave => new(() =>
    {
        var Errortext = RegexUserService.DeclerationVerification(Decleration);
        if (Errortext == null)
        {
            User?.Add(Decleration);
            _service?.NavigateTo<UserMainViewModel>(new ParameterMessage { Message = User });
        }
        else MessageBox.Show(Errortext);
    });
}