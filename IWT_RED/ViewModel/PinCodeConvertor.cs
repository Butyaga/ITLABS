using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace IWT_RED.ViewModel;
internal class PinCodeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string? valueString = value.ToString();
        if (string.IsNullOrEmpty(valueString))
        {
            return string.Empty;
        }

        if (!int.TryParse(parameter.ToString(), out int stringIndex))
        {
            return string.Empty;
        }
        
        if (valueString.Length > stringIndex)
        {
            return valueString[stringIndex].ToString();
        }

        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }
}
