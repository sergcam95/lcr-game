using System;

namespace LcrGame.Simulator.Domain.Exceptions
{
    public class NotSupportedNumberOfPlayersException : Exception
    {
        public NotSupportedNumberOfPlayersException(string errorMessage) : base(errorMessage) { }
    }
}
