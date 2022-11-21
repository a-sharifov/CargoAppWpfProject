using System;

namespace WpfApp6.Model;
public enum OrderStatus : byte
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
    public string? InvoicePrice { get; set; }
    public Uri? ProductImage { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Packages;
}
