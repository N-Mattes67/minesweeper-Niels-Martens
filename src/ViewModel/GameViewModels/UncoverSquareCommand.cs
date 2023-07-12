using Cells;
using Model.Data;
using Model.MineSweeper;
using System.Windows.Input;

namespace ViewModel
{
    public class UncoverSquareCommand : ICommand
    {
        private ICell<IGame> _game { get; set; }
        private readonly Vector2D _position;
        private ICell<int> _numberOfMines;
        private ICell<Vector2D> _isLastPressedOnLoss;
        public UncoverSquareCommand(ICell<IGame> game, Vector2D position, ICell<int> numberOfMines, ICell<Vector2D> isLastPressedOnLoss)
        {
            _game = game;
            _position = position;
            _numberOfMines = numberOfMines;
            _isLastPressedOnLoss = isLastPressedOnLoss;
        }


        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (_game.Value.Board[_position].Status == SquareStatus.Covered && _game.Value.Status == GameStatus.InProgress)
            {
                return true;
            }
            else return false;
        }

        public void Execute(object? parameter)
        {
            _game.Value = _game.Value.UncoverSquare(_position);
            if (_game.Value.Status == GameStatus.Won)
            {
                _numberOfMines.Value = 0;
            }
            if (_game.Value.Status == GameStatus.Lost)
            {
                _isLastPressedOnLoss.Value = _position;
            }
        }
    }
}
