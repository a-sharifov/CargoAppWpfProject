using WpfApp6.Message.Interfaces;

namespace WpfApp6.Model;
public class UserPageModel : ISendable
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Serial { get; set; }
    public string? Address { get; set; }
    public string? FIN { get; set; }
    public string? Number { get; set; }
}