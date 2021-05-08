using System.Collections.Generic;

namespace LcrGame.Simulator.Application.Interfaces
{
    public interface IRandomNumberGenerator
    {
        int Generate(int start, int end);
        IEnumerable<int> Generate(int start, int end, int amount);
    }
}
