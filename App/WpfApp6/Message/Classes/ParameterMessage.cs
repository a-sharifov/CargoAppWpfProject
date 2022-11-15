using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp6.Message.Interfaces;

namespace WpfApp6.Message.Classes
{
    public class ParameterMessage
    {
        public ISendable? Message { get; set; }
    }
}
