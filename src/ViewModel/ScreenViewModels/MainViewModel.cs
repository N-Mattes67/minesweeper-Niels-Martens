using Cells;

namespace ViewModel.ScreenViewModels
{
    public class MainViewModel
    {
        public ICell<ScreenViewModel> CurrentScreen { get; }
        public MainViewModel()
        {
            CurrentScreen = Cell.Create<ScreenViewModel>(null);
            var firstScreen = new SettingsScreenViewModel(CurrentScreen, 10, 0.1, true, Color.Grey);
            CurrentScreen.Value = firstScreen;
        }

        public void tick()
        {
            CurrentScreen.Value.Tick();
        }
    }
}
