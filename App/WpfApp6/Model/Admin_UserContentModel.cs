using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp6.Interface;
using WpfApp6.Message.Interfaces;

namespace WpfApp6.Model
{
    public class Admin_UserContentModel : ISendable, ISerialization
    {
        public Dictionary<string, UserCargoModel> AllUser { get; set; }
        public Admin_UserContentModel()
        {
            AllUser = new();
        }
    }
}
