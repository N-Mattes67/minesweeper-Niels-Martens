using Cells;
using Model.Data;
using Model.MineSweeper;
using ViewModel.ScreenViewModels;

namespace ViewModel
{
    public class GameBoardViewModel
    {
        private readonly ICell<IGameBoard> _board;
        public IEnumerable<RowViewModel> Rows { get; }

        public GameBoardViewModel(ICell<IGame> game, ICell<int> numberOfMines, ISet<Vector2D> mines, Color color)
        {
            _board = game.Derive(g => g.Board);

            List<RowViewModel> rowList = new List<RowViewModel>();
            for (int i = 0; i < _board.Value.Height; i++)
            {
                rowList.Add(new RowViewModel(game, i, numberOfMines, mines, color));
            }
            Rows = rowList;
        }
    }
}
