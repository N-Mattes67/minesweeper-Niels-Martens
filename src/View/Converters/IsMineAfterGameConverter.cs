using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Windows.Data;

namespace View.Converters
{
    public class IsMineAfterGameConverter : IMultiValueConverter
    {
        public object Hide { get; set; }
        public object Won { get; set; }
        public object Lost { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ISet<Vector2D> mines = (ISet<Vector2D>)values[1];
            Vector2D position = (Vector2D)values[2];
            SquareStatus squareStatus = (SquareStatus)values[3];

            switch (values[0])
            {
                case GameStatus.InProgress:
                    return Hide;

                case GameStatus.Won:
                    if (mines.Contains(position)) return Won;
                    else return Hide;

                case GameStatus.Lost:
                    if (mines.Contains(position) && squareStatus != SquareStatus.Flagged) return Lost;
                    else return Hide;

                default:
                    return Hide;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
