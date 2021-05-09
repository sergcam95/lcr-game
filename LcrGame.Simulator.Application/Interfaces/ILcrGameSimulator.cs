using LcrGame.Simulator.Domain.Models;

namespace LcrGame.Simulator.Application.Interfaces
{
    public interface ILcrGameSimulator
    {
        int RunGame(int numberOfPlayers, int initialChipAmount = 3);
        SimulatorOutput RunSetOfGames(int numberOfPlayers, int numberOfGames, int initialChipAmount = 3);
    }
}
