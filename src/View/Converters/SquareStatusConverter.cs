using Model.MineSweeper;
using System;
using System.Globalization;
using System.Windows.Data;

namespace View.Converters
{
    public class SquareStatusConverter : IValueConverter
    {
        public object Uncovered { get; set; }
        public object Covered { get; set; }
        public object Mine { get; set; }
        public object Flagged { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case SquareStatus.Uncovered:
                    return Uncovered;

                case SquareStatus.Covered:
                    return Covered;

                case SquareStatus.Mine:
                    return Mine;

                case SquareStatus.Flagged:
                    return Flagged;

                default:
                    throw new ArgumentException("Not a real square status.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
