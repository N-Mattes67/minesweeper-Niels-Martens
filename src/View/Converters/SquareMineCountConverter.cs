using System;
using System.Globalization;
using System.Windows.Data;

namespace View.Converters
{
    public class SquareMineCountConverter : IValueConverter
    {
        public object Zero { get; set; }
        public object One { get; set; }
        public object Two { get; set; }
        public object Three { get; set; }
        public object Four { get; set; }
        public object Five { get; set; }
        public object Six { get; set; }
        public object Seven { get; set; }
        public object Eight { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case 0:
                    return Zero;
                case 1:
                    return One;
                case 2:
                    return Two;
                case 3:
                    return Three;
                case 4:
                    return Four;
                case 5:
                    return Five;
                case 6:
                    return Six;
                case 7:
                    return Seven;
                default:
                    return Eight;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
