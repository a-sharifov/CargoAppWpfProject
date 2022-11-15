using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp6.Model
{
    public class UserStatusListPreparation
    {
        public List<PreparationDeclerationModel> UserPackages { get; private set; }
        public List<PreparationDeclerationModel> UserOrders { get; private set; }
        public List<PreparationDeclerationModel> UserInFillial { get; private set; }

        public UserStatusListPreparation()
        {
            UserPackages = new();
            UserOrders = new();
            UserInFillial = new();
        }

        public void Add(PreparationDeclerationModel item)
        {
            switch (item.Status)
            {
                case OrderStatus.Packages:
                    UserPackages.Add(item);
                    break;
                case OrderStatus.Orders:
                    UserOrders.Add(item);
                    break;
                case OrderStatus.InFillial:
                    UserInFillial.Add(item);
                    break;
            }
        }
        public void Add(List<PreparationDeclerationModel>? item)
        {
            if (item != null)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    Add(item[i]);
                }
            }
        }
    }
}
