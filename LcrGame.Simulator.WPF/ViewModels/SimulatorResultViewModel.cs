namespace LcrGame.Simulator.WPF.ViewModels
{
    public class SimulatorResultViewModel : BaseViewModel
    {
        private int _averageGame;

        public int AverageGame
        {
            get { return _averageGame; }
            set
            {
                _averageGame = value;
                OnPropertyChanged(nameof(AverageGame));
            }
        }

        private int _shortestGame;

        public int ShortestGame
        {
            get { return _shortestGame; }
            set
            {
                _shortestGame = value;
                OnPropertyChanged(nameof(ShortestGame));
            }
        }

        private int _longestGame;

        public int LongestGame
        {
            get { return _longestGame; }
            set
            {
                _longestGame = value;
                OnPropertyChanged(nameof(LongestGame));
            }
        }
    }
}
