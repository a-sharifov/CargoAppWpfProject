using System.Collections.Generic;

namespace WpfApp6.Model;
public class UserStatusListPreparationModel
{
    public List<PreparationDeclerationModel>? UserPackages { get; private set; } = new();
    public List<PreparationDeclerationModel>? UserOrders { get; private set; } = new();
    public List<PreparationDeclerationModel>? UserInFillial { get; private set; } = new();

    public void Add(PreparationDeclerationModel item)
    {
        switch (item.Status)
        {
            case OrderStatus.Packages:
                UserPackages?.Add(item);
                break;
            case OrderStatus.Orders:
                UserOrders?.Add(item);
                break;
            case OrderStatus.InFillial:
                UserInFillial?.Add(item);
                break;
        }
    }
    public void Add(List<PreparationDeclerationModel>? item)
    {
        for (int i = 0; i < item?.Count; i++)
        {
            Add(item[i]);
        }
    }
}