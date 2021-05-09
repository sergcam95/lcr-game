using LcrGame.Simulator.Application.Interfaces;
using LcrGame.Simulator.Domain.Exceptions;
using LcrGame.Simulator.Domain.Models;
using System;
using System.Collections.Generic;

namespace LcrGame.Simulator.Application.Services
{
    public class LcrGameSimulator : LcrBaseSimulator, ILcrGameSimulator
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public LcrGameSimulator(IRandomNumberGenerator randomNumberGenerator): base(6, 3, 3)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public override int RunGame(int numberOfPlayers, int initialChipAmount = 3)
        {
            if (numberOfPlayers < _minPlayersNumber)
                throw new InvalidSimulatorArgumentsException($"The minimum number of players is 3. Number of players entered: {numberOfPlayers}");

            if(initialChipAmount <= 0)
                throw new InvalidSimulatorArgumentsException($"The minimum initial chip amount is 1. Initial chip amount entered: {initialChipAmount}");

            var players = new List<Player>();
            for (int i = 0; i < numberOfPlayers; i++)
                players.Add(new Player { Chips = initialChipAmount });

            var playersWithoutChips = 0;
            var turns = 0;

            Player currentPlayer;
            int playerIndex = 0;
            int leftPersonIndex;
            int rightPersonIndex;
            string diceSide;
            IEnumerable<int> diceResults;
            while (playersWithoutChips != numberOfPlayers)
            {
                currentPlayer = players[playerIndex];

                leftPersonIndex = GetLeftPersonIndex(playerIndex, numberOfPlayers);
                rightPersonIndex = GetNextPlayerIndex(playerIndex, numberOfPlayers);

                if (currentPlayer.Chips == 0)
                {
                    playerIndex = rightPersonIndex;
                    continue;
                }

                diceResults = _randomNumberGenerator.Generate(1, _diceSideNumber, Math.Min(currentPlayer.Chips, _maxDiceNumberPerTurn));
                foreach (var diceSideNumber in diceResults)
                {
                    diceSide = GetDiceSide(diceSideNumber);

                    if (diceSide == "dot")
                        continue;

                    if (diceSide == "L")
                    {
                        if (players[leftPersonIndex].Chips == 0)
                            playersWithoutChips--;

                        players[leftPersonIndex].Chips++;
                    } 
                    else if(diceSide == "R")
                    {
                        if (players[rightPersonIndex].Chips == 0)
                            playersWithoutChips--;

                        players[rightPersonIndex].Chips++;
                    }

                    currentPlayer.Chips--;
                }

                if (currentPlayer.Chips == 0)
                    playersWithoutChips++;

                turns++;
                playerIndex = rightPersonIndex;
            }

            return turns;
        }

        public override SimulatorOutput RunSetOfGames(int numberOfPlayers, int numberOfGames, int initialChipAmount = 3)
        {
            if (numberOfGames <= 0)
                throw new InvalidSimulatorArgumentsException($"The minimum number of games is 1. Number of games entered: {numberOfGames}");

            var turnsSum = 0;
            var longestGameTurns = 0;
            var shortestGameTurns = 0;
            int currentGameTurns;
            for(int i = 0; i < numberOfGames; i++)
            {
                currentGameTurns = RunGame(numberOfPlayers, initialChipAmount);

                turnsSum += currentGameTurns;
                longestGameTurns = Math.Max(longestGameTurns, currentGameTurns);

                if (i == 0)
                    shortestGameTurns = currentGameTurns;
                else 
                    shortestGameTurns = Math.Min(shortestGameTurns, currentGameTurns);
            }

            return new SimulatorOutput
            {
                LongestGameTurns = longestGameTurns,
                ShortestGameTurns = shortestGameTurns,
                AverageGameTurns = turnsSum / numberOfGames
            };
        }
    }
}
