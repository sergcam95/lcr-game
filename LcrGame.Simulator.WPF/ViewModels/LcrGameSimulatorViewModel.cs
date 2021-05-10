using LcrGame.Simulator.WPF.Models;

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

        private SimulatorResultViewModel _simulatorOutput;

        public SimulatorResultViewModel SimulatorOutput
        {
            get { return _simulatorOutput; }
            set
            {
                _simulatorOutput = value;
                OnPropertyChanged(nameof(SimulatorOutput));
            }
        }
    }
}
