using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp6.Service.Classes;
public class ArrayMultiValueConverterService : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return values.Clone();
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}