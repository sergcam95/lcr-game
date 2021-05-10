using LcrGame.Simulator.Application.Interfaces;

namespace LcrGame.Simulator.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly BaseViewModel _currentViewModel;
        public MainViewModel(LcrGameSimulatorViewModel lcrGameSimulatorViewModel)
        {
            _currentViewModel = lcrGameSimulatorViewModel;
        }

        public BaseViewModel CurrentViewModel => _currentViewModel;
    }
}
