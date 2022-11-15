using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace WpfApp6.Service.Classes
{
    public class EnumBindingSourceExtensionService : MarkupExtension
    {
        public Type EnumType { get; set; }

        public EnumBindingSourceExtensionService(Type enumType)
        {
            if (enumType is null || !enumType.IsEnum)
                throw new Exception("enumType is not Enum");
            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
