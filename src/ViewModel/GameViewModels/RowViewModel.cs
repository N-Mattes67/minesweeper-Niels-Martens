using Cells;
using Model.Data;
using Model.MineSweeper;
using ViewModel.ScreenViewModels;

namespace ViewModel
{
    public class RowViewModel
    {
        public IEnumerable<SquareViewModel> Squares { get; }

        public RowViewModel(ICell<IGame> game, int rowIndex, ICell<int> numberOfMines, ISet<Vector2D> mines, Color color)
        {
            Squares = CreateSquareViewModels(game, rowIndex, numberOfMines, mines, color);
        }

        private static IEnumerable<SquareViewModel> CreateSquareViewModels(ICell<IGame> game, int rowIndex, ICell<int> numberOfMines, ISet<Vector2D> mines, Color color)
        {
            List<SquareViewModel> result = new();

            for (int i = 0; i < game.Value.Board.Height; i++)
            {
                result.Add(new SquareViewModel(game, new Vector2D(i, rowIndex), numberOfMines, mines, color));
            }

            return result;
        }
    }
}
