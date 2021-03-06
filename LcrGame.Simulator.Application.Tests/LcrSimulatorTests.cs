using LcrGame.Simulator.Application.Interfaces;
using LcrGame.Simulator.Application.Services;
using LcrGame.Simulator.Domain.Exceptions;
using Xunit;

namespace LcrGame.Simulator.Application.Tests
{
    public class LcrSimulatorTests
    {

        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly ILcrGameSimulator _lcrGameSimulator;

        public LcrSimulatorTests()
        {
            _randomNumberGenerator = new RandomNumberGenerator();
            _lcrGameSimulator = new LcrGameSimulator(_randomNumberGenerator);
        }

        [Fact]
        public void RunGame_MoreThanThreePlayers_TurnsLargerThanZero()
        {
            var numberOfPlayers = 4;

            var turns = _lcrGameSimulator.RunGame(numberOfPlayers);

            Assert.NotEqual(0, turns);
        }

        [Fact]
        public void RunGame_TwoPlayers_ThrowsInvalidSimulatorArgumentsException()
        {
            var numberOfPlayers = 2;

            Assert.Throws<InvalidSimulatorArgumentsException>(() => _lcrGameSimulator.RunGame(numberOfPlayers));
        }

        [Fact]
        public void RunGame_ZeroInitialChips_ThrowsInvalidSimulatorArgumentsException()
        {
            var numberOfPlayers = 3;
            var initialChipAmount = 0;

            Assert.Throws<InvalidSimulatorArgumentsException>(() => _lcrGameSimulator.RunGame(numberOfPlayers, initialChipAmount));
        }

        [Fact]
        public void RunSetOfGames_MoreThanThreePlayers_NoValueSetToZero()
        {
            var numberOfPlayers = 4;

            var simulatorOutput = _lcrGameSimulator.RunSetOfGames(numberOfPlayers, 100);

            Assert.NotNull(simulatorOutput);
            Assert.NotEqual(0, simulatorOutput.AverageGameTurns);
            Assert.NotEqual(0, simulatorOutput.LongestGameTurns);
            Assert.NotEqual(0, simulatorOutput.ShortestGameTurns);
        }

        [Fact]
        public void RunSetOfGames_TwoPlayers_ThrowsInvalidSimulatorArgumentsException()
        {
            var numberOfPlayers = 2;
            var numberOfGames = 2;

            Assert.Throws<InvalidSimulatorArgumentsException>(() => _lcrGameSimulator.RunSetOfGames(numberOfPlayers, numberOfGames));
        }

        [Fact]
        public void RunSetOfGames_ZeroGames_ThrowsInvalidSimulatorArgumentsException()
        {
            var numberOfPlayers = 4;
            var numberOfGames = 0;

            Assert.Throws<InvalidSimulatorArgumentsException>(() => _lcrGameSimulator.RunSetOfGames(numberOfPlayers, numberOfGames));
        }

        [Fact]
        public void RunSetOfGames_ZeroInitialChipAmount_ThrowsInvalidSimulatorArgumentsException()
        {
            var numberOfPlayers = 4;
            var numberOfGames = 5;
            var initialChipAmount = 0;

            Assert.Throws<InvalidSimulatorArgumentsException>(() => _lcrGameSimulator.RunSetOfGames(numberOfPlayers, numberOfGames, initialChipAmount));
        }
    }
}
