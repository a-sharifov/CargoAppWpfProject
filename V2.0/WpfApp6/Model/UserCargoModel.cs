using System.Collections.Generic;
using WpfApp6.Message.Interfaces;

namespace WpfApp6.Model;
public class UserCargoModel : ISendable
{
    public UserPageModel? User { get; set; } = new();
    public List<PreparationDeclerationModel>? UserOrder { get; set; } = new();

    public void Add(PreparationDeclerationModel model)
    {
        UserOrder!.Add(model);
    }

    public void Remove(PreparationDeclerationModel model)
    {
        UserOrder!.Remove(model);
    }
}

