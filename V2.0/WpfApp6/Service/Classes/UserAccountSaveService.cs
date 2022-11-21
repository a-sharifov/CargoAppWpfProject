using WpfApp6.Model;

namespace WpfApp6.Service.Classes;
public static class UserAccountSaveService
{
    public static void SaveUser()
    {
        FileService.SaveAs(SerialiazibleService.Serialization(AdminUserContentModel.UserInfo!), "Admin.txt");
        App.Current.Shutdown();
    }
     
    public static void SaveUser(UserCargoModel user)
    {
        AdminUserContentModel.UserInfo![user!.User!.UserName!] = user;
        SaveUser();
    }
}