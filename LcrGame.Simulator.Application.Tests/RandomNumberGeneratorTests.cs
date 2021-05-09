using LcrGame.Simulator.Application.Interfaces;
using LcrGame.Simulator.Application.Services;
using System.Linq;
using Xunit;

namespace LcrGame.Simulator.Application.Tests
{
    public class RandomNumberGeneratorTests
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        public RandomNumberGeneratorTests()
        {
            _randomNumberGenerator = new RandomNumberGenerator();
        }

        [Fact]
        public void GenerateOneRandomNumber_BetweenOneToSeven_MultipleTimes()
        {
            var start = 1;
            var end = 7;

            int actualResult;
            for(int i = 0; i < 10; i++)
            {
                actualResult = _randomNumberGenerator.Generate(start, end);

                Assert.InRange(actualResult, start, end);
            }
        }

        [Fact]
        public void GenerateMultipleRandomNumbers_BetweenOneToSix_FiveRandomNumbers()
        {
            var start = 1;
            var end = 7;
            var numberOfRandomNumbers = 5;

            var randomNumbers = _randomNumberGenerator.Generate(start, end, numberOfRandomNumbers);

            Assert.Equal(numberOfRandomNumbers, randomNumbers.Count());
            foreach (var randomNumber in randomNumbers)
            {
                Assert.InRange(randomNumber, start, end);
            }
        }
    }
}
