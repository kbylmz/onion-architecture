using System;
using System.Collections.Generic;

namespace Hestia.Domain.Contracts
{
    public interface IEntity<TDocument>
    {
        Guid Id { get; }
        int Version { get; }
        IList<IEvent> UncommittedEvents { get; }
        bool IsPermanentlyDeleted { get; }
        void DeletePermanently();
        void Load(TDocument document);
        TDocument ToDocument();
    }
}
