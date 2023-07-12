using Cells;
using Model.Data;
using Model.MineSweeper;
using System.Windows.Input;
using ViewModel.ScreenViewModels;

namespace ViewModel
{
    public class SquareViewModel
    {
        public ICell<Square> Square { get; }
        public ICommand Uncover { get; }
        public ICommand PlaceFlag { get; }
        public Vector2D Position { get; }
        public ISet<Vector2D> MineLocations { get; }
        public ICell<GameStatus> GameStatus { get; }
        public Color Color { get; }
        public ICell<Vector2D> IsLastPressedOnLoss { get; } = Cell.Create(new Vector2D(-1, -1));

        public SquareViewModel(ICell<IGame> game, Vector2D position, ICell<int> numberOfMines, ISet<Vector2D> mines, Color color)
        {
            Square = game.Derive(g => g.Board[position]);
            Position = position;
            Uncover = new UncoverSquareCommand(game, position, numberOfMines, IsLastPressedOnLoss);
            PlaceFlag = new PlaceFlagCommand(game, position, numberOfMines);
            MineLocations = mines;
            GameStatus = game.Derive(g => g.Status);
            Color = color;
        }
    }
}
