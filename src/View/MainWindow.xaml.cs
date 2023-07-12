using System;
using System.Windows;
using System.Windows.Threading;
using ViewModel.ScreenViewModels;

namespace View
{
    public partial class MainWindow : Window
    {
        public DispatcherTimer timer;
        public MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();

            viewModel = new MainViewModel();
            this.DataContext = viewModel;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            viewModel.tick();
        }
    }
}
