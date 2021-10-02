using System;

namespace Hestia.Domain.Contracts
{
    public interface IEvent : ICloneable
    {
        Guid Id { get; }
        Guid AggregateId { get; }
        string Payload { get; }
    }
}
