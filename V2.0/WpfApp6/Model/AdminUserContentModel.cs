using WpfApp6.Service.Classes;

namespace WpfApp6.Model;
public static class AdminUserContentModel
{
    public static AdminUserContentInfoModel UserInfo { get; set; } 
    static AdminUserContentModel()
    {
        var Save = FileService.ReadAs("Admin.txt");
        UserInfo = SerialiazibleService.Deserialization<AdminUserContentInfoModel>(Save) ?? new AdminUserContentInfoModel();
    }
} 