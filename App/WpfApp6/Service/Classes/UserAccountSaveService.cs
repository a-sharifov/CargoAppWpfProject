using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp6.Model;
using WpfApp6.ViewModel;

namespace WpfApp6.Service.Classes
{
    public static class UserAccountSaveService
    {
        private static SignInViewModel? _signInViewModel;

        static UserAccountSaveService()
        {
            _signInViewModel = App.Container?.GetInstance<SignInViewModel>();
        }

        public static void SaveUser()
        {
            FileService.SaveAs(SerialiazibleService.Serialization(_signInViewModel?.ContentModel), "Admin.txt");
            App.Current.Shutdown();
        }

        public static void SaveUser(UserCargoModel? User) 
        {
            if(User != null)
            _signInViewModel.ContentModel.AllUser[User.User.UserName] = User;
            SaveUser();
        }
    }
}
