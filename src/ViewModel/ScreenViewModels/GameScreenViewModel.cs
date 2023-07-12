using Cells;
using Model.MineSweeper;
using System.Windows.Input;

namespace ViewModel.ScreenViewModels
{
    public class GameScreenViewModel : ScreenViewModel
    {
        public ICommand SwitchToSettingsScreen { get; }
        public ICommand SwitchToGameScreen { get; }
        public ICell<int> CurrentTime { get; set; }
        public ICell<String> Time { get; set; }
        public GameViewModel Game { get; set; }
        public ICell<int> NumberOfMines { get; set; }
        public GameScreenViewModel(ICell<ScreenViewModel> currentScreen, int boardSize, double mineProbability, bool flooding, Color color) : base(currentScreen)
        {
            SwitchToSettingsScreen = new ActionCommand(() => CurrentScreen.Value = new SettingsScreenViewModel(this.CurrentScreen, boardSize, mineProbability, flooding, color));
            SwitchToGameScreen = new ActionCommand(() => CurrentScreen.Value = new GameScreenViewModel(this.CurrentScreen, boardSize, mineProbability, flooding, color));

            Game = new GameViewModel(IGame.CreateRandom(boardSize, mineProbability, flooding), color);
            NumberOfMines = Game.NumberOfMines;
            CurrentTime = Cell.Create(0);
            Time = Cell.Create("00:00");
        }

        public override void Tick()
        {
            if (Game.Status.Value == GameStatus.InProgress)
            {
                CurrentTime.Value++;
                int minutes = CurrentTime.Value / 60;
                int seconds = CurrentTime.Value % 60;
                Time.Value = minutes.ToString("00") + ":" + seconds.ToString("00");
            }
        }
    }
}
