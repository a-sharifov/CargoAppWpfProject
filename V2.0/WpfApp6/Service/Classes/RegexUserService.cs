using WpfApp6.Model;

namespace WpfApp6.Service.Classes;
public static class RegexUserService
{
    public static bool SuchAUser(string? user)
    {
        return AdminUserContentModel.UserInfo!.AllUser!.ContainsKey(user!) == true ? false : true;
    }

    public static bool NotAnEmpty(string item)
    {
        return !string.IsNullOrWhiteSpace(item);
    }

    public static bool CheckForEmptiness(UserPageModel user)
    {
        return (NotAnEmpty(user.Password!) && NotAnEmpty(user.UserName!) && NotAnEmpty(user.Serial!)
        && NotAnEmpty(user.Address!) && NotAnEmpty(user.Number!) && NotAnEmpty(user.FIN!));
    }

    public static bool CheckForEmptinessDecleration(PreparationDeclerationModel preparation)
    {
        return (NotAnEmpty(preparation.InvoicePrice!) && NotAnEmpty(preparation.Note!) && NotAnEmpty(preparation.WareHouse!)
       && NotAnEmpty(preparation.ProductCategory!) && NotAnEmpty(preparation.ProductImage!.AbsoluteUri!) && NotAnEmpty(preparation.TrackingNumber!) 
       && NotAnEmpty(preparation.Quantity!));
    }

    public static string? LengthCheckDecleration(PreparationDeclerationModel preparation)
    {
        if (preparation.InvoicePrice!.Length < 1) return "Invoice price short";
        if (preparation.Note!.Length < 1) return "Note short";
        if (preparation.TrackingNumber!.Length < 2) return "Tracking number short";
        if (preparation.ProductCategory!.Length < 2) return "Product category short";
        if (preparation.Quantity!.Length < 2) return "Quantity short";
        if (preparation.SiteName!.Length < 8) return "Site name quantity";
        return null;
    }

    public static string? LengthCheck(UserPageModel user)
    {
        if (user.UserName!.Length < 5) return "User name short";
        if (user.Password!.Length < 6) return "Password short";
        if (user.FIN!.Length < 7) return "Fin short";
        if (user.Serial!.Length < 6) return "Serial short";
        if (user.Address!.Length < 6) return "Address short";
        if (user.Number!.Length < 8) return "Number short";
        return null;
    }
    public static string? UserVerification(UserPageModel user)
    {
        if (!SuchAUser(user.UserName)) return "There is such a user";
        if (!CheckForEmptiness(user))  return "empty lines";
        return LengthCheck(user);
    }

    public static string? DeclerationVerification(PreparationDeclerationModel preparation)
    {
        if (!CheckForEmptinessDecleration(preparation)) return "empty lines";
        return LengthCheckDecleration(preparation);
    }
}