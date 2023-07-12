using Model.Data;
using System;
using System.Globalization;
using System.Windows.Data;

namespace View.Converters
{
    public class IsLastPressedOnLossConverter : IMultiValueConverter
    {
        public object Yes { get; set; }
        public object No { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] != null)
            {
                Vector2D lastPressed = (Vector2D)values[0];
                Vector2D position = (Vector2D)values[1];
                if (lastPressed == position) return Yes;
            }
            return No;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
