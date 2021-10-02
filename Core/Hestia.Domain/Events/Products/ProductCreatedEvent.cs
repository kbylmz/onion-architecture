using Hestia.Domain.Contracts;
using System;

namespace Hestia.Domain.Events.Products
{
    public class ProductCreatedEvent : IEvent
    {
        public Guid Id { get; }
        public Guid AggregateId { get; }
        public string Payload { get; }

        public ProductCreatedEvent(Guid aggregateId, string payload)
        {
            Id = Guid.NewGuid();
            AggregateId = aggregateId;
            Payload = payload;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
