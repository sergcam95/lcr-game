using LcrGame.Simulator.Application.Interfaces;
using LcrGame.Simulator.WPF.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace LcrGame.Simulator.WPF.ViewModels
{
    public class LcrGameSimulatorViewModel : BaseViewModel, INotifyDataErrorInfo
    {
        private readonly ErrorsViewModel _errorsViewModel;

        private int _playersNumber = 3;

        public int PlayersNumber
        {
            get { return _playersNumber; }
            set 
            {
                _playersNumber = value;

                _errorsViewModel.ClearErrors(nameof(PlayersNumber));
                if(_playersNumber < 3)
                {
                    _errorsViewModel.AddError(nameof(PlayersNumber), "Minimum players are 3");
                }

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

                _errorsViewModel.ClearErrors(nameof(GamesNumber));
                if (_gamesNumber <= 0)
                {
                    _errorsViewModel.AddError(nameof(GamesNumber), "Number of games should be at least 1");
                }

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
            
            _errorsViewModel = new ErrorsViewModel();
            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;
        }

        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(HasErrors));
        }

        public ICommand RunSimulatorCommand { get; set; }

        public bool HasErrors => _errorsViewModel.HasErrors;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsViewModel.GetErrors(propertyName);
        }


    }
}
