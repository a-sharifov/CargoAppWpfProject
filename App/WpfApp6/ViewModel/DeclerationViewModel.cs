using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WpfApp6.Message.Classes;
using WpfApp6.Model;
using WpfApp6.Service.Interface;

namespace WpfApp6.ViewModel
{
    public class DeclerationViewModel : ViewModelBase
    {
        public PreparationDeclerationModel declerationModel { get; set; }
        public UserCargoModel? User { get; set; }
        public BitmapImage? ProductImage { get; set; }
        public string? ErrorText { get; set; }
        private readonly INavigationService? _service;

        public DeclerationViewModel(INavigationService? service, IMessenger messenger)
        {
            declerationModel = new();
            _service = service;
            messenger.Register<ParameterMessage>(this, param => {
                declerationModel = new();
                ErrorText = null;
                User = param?.Message as UserCargoModel;
            });
        }

        public RelayCommand ClickReturn => new(() => { _service?.NavigateTo<UserMainViewModel>(new ParameterMessage { Message = User }); });
        public RelayCommand ImageDownoload => new(() => {
            OpenFileDialog openImage = new();
            openImage.Filter = "Image files(*.PNG, *.JPG, *.BMP)|*.png;*.jpg;*.bmp";
            if(openImage.ShowDialog() == true)
            {
                declerationModel.ProductImage = new Uri(openImage.FileName);
                ProductImage = new(declerationModel.ProductImage);
            }
        });
        public RelayCommand ClickSave => new(() => {
            if ( !string.IsNullOrWhiteSpace(declerationModel?.SiteName) && !string.IsNullOrWhiteSpace(declerationModel?.WareHouse)
              && !string.IsNullOrWhiteSpace(declerationModel?.TrackingNumber) && !string.IsNullOrWhiteSpace(declerationModel?.Quantity) && !string.IsNullOrWhiteSpace(declerationModel?.Note)
              && !string.IsNullOrWhiteSpace(declerationModel?.ProductCategory))
            {
                User?.UserOrder?.Add(declerationModel);
                _service?.NavigateTo<UserMainViewModel>(new ParameterMessage { Message = User });
            }
            else ErrorText = "forgot to lead the field";
        });
    }
}
