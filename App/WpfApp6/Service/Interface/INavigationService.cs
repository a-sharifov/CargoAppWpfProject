using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp6.Message.Classes;

namespace WpfApp6.Service.Interface
{
    public interface INavigationService
    {
        public void NavigateTo<T>(ParameterMessage? message = null) where T : ViewModelBase;
    }
}
