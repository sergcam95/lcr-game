using LcrGame.Simulator.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace LcrGame.Simulator.Application.Services
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly Random _random;

        public RandomNumberGenerator()
        {
            _random = new();
        }

        public int Generate(int start, int end)
        {
            return _random.Next(start, end);
        }

        public IEnumerable<int> Generate(int start, int end, int count)
        {
            for (int i = start; i <= end; i++)
            {
                yield return _random.Next(start, end);
            }
        }
    }
}
