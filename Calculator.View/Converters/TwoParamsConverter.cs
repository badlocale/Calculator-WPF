using System;
using System.Globalization;
using System.Windows.Data;

namespace Calculator.View.Converters
{
    class TwoParamsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
            {
                throw new InvalidCastException();
            }

            Tuple<object, object> tuple = new Tuple<object, object>(values[0], values[1]);
            
            return tuple;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var array = value as object[];

            if (array != null)
            {
                throw new InvalidCastException();
            }

            return array!;
        }
    }
}
