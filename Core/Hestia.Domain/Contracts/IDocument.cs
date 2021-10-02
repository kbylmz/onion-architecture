using System;

namespace Hestia.Domain.Contracts
{
    public interface IDocument
    {
        Guid Id { get; set; }

        int Version { get; set; }
    }
}
