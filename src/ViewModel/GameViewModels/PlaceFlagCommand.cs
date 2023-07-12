using Cells;
using Model.Data;
using Model.MineSweeper;
using System.Windows.Input;

namespace ViewModel
{
    internal class PlaceFlagCommand : ICommand
    {
        private ICell<IGame> _game { get; set; }
        private readonly Vector2D _position;
        private ICell<int> _numberOfMines;
        public PlaceFlagCommand(ICell<IGame> game, Vector2D position, ICell<int> numberOfMines)
        {
            _game = game;
            _position = position;
            _numberOfMines = numberOfMines;
        }


        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if ((_game.Value.Board[_position].Status == SquareStatus.Covered || _game.Value.Board[_position].Status == SquareStatus.Flagged) && _game.Value.Status == GameStatus.InProgress)
            {
                return true;
            }
            else return false;
        }

        public void Execute(object? parameter)
        {
            if (_game.Value.Board[_position].Status == SquareStatus.Flagged)
            {
                _game.Value = _game.Value.ToggleFlag(_position);
                _numberOfMines.Value++;
            }
            else
            {
                _game.Value = _game.Value.ToggleFlag(_position);
                _numberOfMines.Value--;
            }
        }
    }
}
