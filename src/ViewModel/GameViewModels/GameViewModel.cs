using Cells;
using Model.Data;
using Model.MineSweeper;
using ViewModel.ScreenViewModels;

namespace ViewModel
{
    public class GameViewModel
    {
        private readonly ICell<IGame> _game;

        public GameBoardViewModel Board { get; }

        public ISet<Vector2D> Mines { get; }
        public ICell<int> NumberOfMines { get; }

        public ICell<GameStatus> Status { get; }

        public GameViewModel(IGame game, Color color)
        {
            _game = Cell.Create(game);
            Status = _game.Derive(g => g.Status);
            Mines = GetMines(game);
            NumberOfMines = Cell.Create(Mines.Count);
            Board = new GameBoardViewModel(_game, NumberOfMines, Mines, color);
        }

        private ISet<Vector2D> GetMines(IGame game)
        {
            ICell<IGame> cell = Cell.Create(game);

            while (cell.Value.Status == GameStatus.InProgress)
            {
                for (int y = 1; y < game.Board.Height; y++)
                {
                    for (int x = 1; x < game.Board.Width; x++)
                    {
                        if (cell.Value.Board[new Vector2D(x, y)].Status == SquareStatus.Covered && cell.Value.Status == GameStatus.InProgress)
                        {
                            cell.Value = cell.Value.UncoverSquare(new Vector2D(x, y));
                        }
                    }
                }
            }
            return cell.Value.Mines;
        }
    }
}