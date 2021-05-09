using LcrGame.Simulator.Application.Interfaces;
using LcrGame.Simulator.Domain.Models;

namespace LcrGame.Simulator.Application.Services
{
    public abstract class LcrBaseSimulator : ILcrGameSimulator
    {
        protected readonly int _diceSideNumber;
        protected readonly int _maxDiceNumberPerTurn;
        protected readonly int _minPlayersNumber;

        public LcrBaseSimulator(int diceSideNumber, int maxDiceNumberPerTurn, int minPlayersNumber)
        {
            _diceSideNumber = diceSideNumber;
            _maxDiceNumberPerTurn = maxDiceNumberPerTurn;
            _minPlayersNumber = minPlayersNumber;
        }

        public abstract int RunGame(int numberOfPlayers, int initialChipAmount = 3);
        public abstract SimulatorOutput RunSetOfGames(int numberOfPlayers, int numberOfGames, int initialChipAmount = 3);
        protected virtual string GetDiceSide(int number)
        {
            if (number == 1)
                return "L";

            if (number == 2)
                return "C";

            if (number == 3)
                return "R";

            return "dot";
        }

        protected virtual int GetLeftPersonIndex(int currentPlayerIndex, int numberOfPlayers)
        {
            var leftPersonIndex = currentPlayerIndex - 1;
            if (leftPersonIndex < 0)
                return numberOfPlayers - 1;

            return leftPersonIndex;
        }

        protected virtual int GetNextPlayerIndex(int currentPlayerIndex, int numberOfPlayers)
        {
            var rightPersonIndex = currentPlayerIndex + 1;
            if (rightPersonIndex >= numberOfPlayers)
                return 0;

            return rightPersonIndex;
        }
    }
}
