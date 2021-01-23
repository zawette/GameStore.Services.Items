using System;

namespace Domain.Exceptions
{
    [Serializable]
    internal class InvalidAggregateRootIdException : DomainException
    {
        public override string Code { get; } = "invalid_aggregate_id";

        public Guid Id { get; }

        public InvalidAggregateRootIdException(Guid id) : base($"Invalid aggregate id: {id}")
            => Id = id;
    }
}