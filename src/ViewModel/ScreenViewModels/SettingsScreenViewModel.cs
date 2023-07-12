using Cells;
using Model.MineSweeper;
using System.Windows.Input;

namespace ViewModel.ScreenViewModels
{
    public class SettingsScreenViewModel : ScreenViewModel
    {
        public ICommand SwitchToGameScreen { get; }
        public int MaxBoardSize => IGame.MaximumBoardSize;
        public int MinBoardSize => IGame.MinimumBoardSize;
        public int BoardSize { get; set; }
        public bool Flooding { get; set; }
        public double MineProbability { get; set; }
        public Color ChosenColor { get; set; }

        public SettingsScreenViewModel(ICell<ScreenViewModel> currentScreen, int prevBoardSize, double prevMineProbability, bool prevFlooding, Color prevColor) : base(currentScreen)
        {
            BoardSize = prevBoardSize;
            Flooding = prevFlooding;
            MineProbability = prevMineProbability;
            ChosenColor = prevColor;
            SwitchToGameScreen = new ActionCommand(() => CurrentScreen.Value = new GameScreenViewModel(this.CurrentScreen, BoardSize, MineProbability, Flooding, ChosenColor));
        }

        public override void Tick()
        {
        }
    }
}
