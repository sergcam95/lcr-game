using System;

namespace LcrGame.Simulator.Domain.Exceptions
{
    public class InvalidSimulatorArgumentsException : Exception
    {
        public InvalidSimulatorArgumentsException(string errorMessage) : base(errorMessage) { }
    }
}
