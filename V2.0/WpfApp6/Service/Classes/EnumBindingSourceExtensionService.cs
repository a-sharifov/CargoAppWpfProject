using System;
using System.Windows.Markup;

namespace WpfApp6.Service.Classes;
public class EnumBindingSourceExtensionService : MarkupExtension
{
    public Type? EnumType { get; set; }

    public EnumBindingSourceExtensionService(Type enumType)
    {
        EnumType = enumType;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return Enum.GetValues(EnumType!);
    }
}