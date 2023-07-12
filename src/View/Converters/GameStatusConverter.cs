using Model.MineSweeper;
using System;
using System.Globalization;
using System.Windows.Data;

namespace View.Converters
{
    public class GameStatusConverter : IValueConverter
    {
        public object InProgress { get; set; }
        public object Won { get; set; }
        public object Lost { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case GameStatus.InProgress:
                    return InProgress;

                case GameStatus.Won:
                    return Won;

                case GameStatus.Lost:
                    return Lost;

                default:
                    throw new ArgumentException("Not a real game status.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
