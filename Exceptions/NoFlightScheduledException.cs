using System.Runtime.Serialization;

namespace Service
{
    [Serializable]
    public class NoFlightScheduledException : Exception
    {
        public NoFlightScheduledException()
        {
        }

        public NoFlightScheduledException(string? message) : base(message)
        {
        }

        public NoFlightScheduledException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoFlightScheduledException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}