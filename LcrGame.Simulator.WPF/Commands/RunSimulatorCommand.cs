using LcrGame.Simulator.Application.Interfaces;
using LcrGame.Simulator.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace LcrGame.Simulator.WPF.Commands
{
    public class RunSimulatorCommand : ICommand
    {
        private readonly LcrGameSimulatorViewModel _lcrGameSimulatorViewModel;
        private readonly ILcrGameSimulator _lcrGameSimulator;

        public RunSimulatorCommand(LcrGameSimulatorViewModel lcrGameSimulatorViewModel, ILcrGameSimulator lcrGameSimulator)
        {
            _lcrGameSimulatorViewModel = lcrGameSimulatorViewModel;
            _lcrGameSimulator = lcrGameSimulator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                var simulatorResult = _lcrGameSimulator.RunSetOfGames(_lcrGameSimulatorViewModel.PlayersNumber,
                _lcrGameSimulatorViewModel.GamesNumber);

                _lcrGameSimulatorViewModel.SimulatorOutput = new SimulatorResultViewModel
                {
                    AverageGame = simulatorResult.AverageGameTurns,
                    LongestGame = simulatorResult.LongestGameTurns,
                    ShortestGame = simulatorResult.ShortestGameTurns,
                };
            }
            catch
            {
                _lcrGameSimulatorViewModel.SimulatorOutput = null;
            }
            
        }
    }
}
