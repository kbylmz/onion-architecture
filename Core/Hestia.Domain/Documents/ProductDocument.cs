using Hestia.Domain.Contracts;
using System;

namespace Hestia.Domain.Documents
{
    public class ProductDocument : IDocument
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
