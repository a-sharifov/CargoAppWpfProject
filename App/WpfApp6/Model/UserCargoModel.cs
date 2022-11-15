using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp6.Message.Interfaces;

namespace WpfApp6.Model
{
    public class UserCargoModel : ISendable
    {
        public UserPageModel? User { get; set; }
        public List<PreparationDeclerationModel>? UserOrder { get; set; }
        public UserCargoModel()
        {
            User = new();
            UserOrder = new();
        }
    }
}
