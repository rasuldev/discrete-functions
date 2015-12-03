using System;

namespace DiscreteFunctions
{
    public class ConsistenceException : Exception
    {
        public ConsistenceException() : this("Assigned array must have the same dimension as source array")
        { }

        public ConsistenceException(string message)
            : base(message)
        { }
    }

    public class NotCompatibleException : Exception
    {
        public NotCompatibleException()
            : this("Discrete functions must have the same size of coordinates")
        { }

        public NotCompatibleException(string message)
            : base(message)
        { }
    }

    public class NotApplicable : Exception
    {
        public NotApplicable() : this("Can't set X for this type of series, because X is dynamically calculated")
        {
        }

        public NotApplicable(string message) : base(message)
        {
        }
    }
}