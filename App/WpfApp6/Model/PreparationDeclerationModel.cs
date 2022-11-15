using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp6.Model
{
    public enum OrderStatus
    {
        Packages,
        Orders,
        InFillial,
    }
    public class PreparationDeclerationModel
    {
        public string? WareHouse { get; set; }
        public string? TrackingNumber { get; set; }
        public string? Quantity { get; set; }
        public string? SiteName { get; set; }
        public string? ProductCategory { get; set; }
        public string? Note { get; set; }
        public double InvoicePrice { get; set; }
        public Uri? ProductImage { get; set; }
        public OrderStatus Status { get; set; }

        public PreparationDeclerationModel()
        {
            Status = OrderStatus.Packages;
        }

    }
}
