using LcrGame.Simulator.Application.Interfaces;
using LcrGame.Simulator.WPF.Commands;
using System.Windows.Input;

namespace LcrGame.Simulator.WPF.ViewModels
{
    public class LcrGameSimulatorViewModel : BaseViewModel
    {
        private int _playersNumber = 3;

        public int PlayersNumber
        {
            get { return _playersNumber; }
            set 
            {
                _playersNumber = value; 
                OnPropertyChanged(nameof(PlayersNumber));
            }
        }

        private int _gamesNumber = 100;

        public int GamesNumber
        {
            get { return _gamesNumber; }
            set
            {
                _gamesNumber = value;
                OnPropertyChanged(nameof(GamesNumber));
            }
        }

        private SimulatorResultViewModel _simulatorOutput = new();

        public SimulatorResultViewModel SimulatorOutput
        {
            get { return _simulatorOutput; }
            set
            {
                _simulatorOutput = value;
                OnPropertyChanged(nameof(SimulatorOutput));
            }
        }

        public LcrGameSimulatorViewModel(ILcrGameSimulator lcrGameSimulator)
        {
            RunSimulatorCommand = new RunSimulatorCommand(this, lcrGameSimulator);
        }

        public ICommand RunSimulatorCommand { get; set; }
    }
}
