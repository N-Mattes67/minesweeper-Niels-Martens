using Cells;

namespace ViewModel.ScreenViewModels
{
    public abstract class ScreenViewModel
    {
        protected ScreenViewModel(ICell<ScreenViewModel> currentScreen)
        {
            CurrentScreen = currentScreen;
        }
        protected ICell<ScreenViewModel> CurrentScreen { get; }

        public abstract void Tick();
    }
}
