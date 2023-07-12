using System;
using System.Globalization;
using System.Windows.Data;
using ViewModel.ScreenViewModels;

namespace View.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object Green { get; set; }
        public object Pink { get; set; }
        public object Blue { get; set; }
        public object Yellow { get; set; }
        public object Gray { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case Color.Green:
                    return Green;

                case Color.Pink:
                    return Pink;

                case Color.Blue:
                    return Blue;

                case Color.Yellow:
                    return Yellow;

                default:
                    return Gray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
