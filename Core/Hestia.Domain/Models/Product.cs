using Hestia.Domain.Documents;
using Hestia.Domain.Events.Products;
using System;

namespace Hestia.Domain.Models
{
    public class Product : EntityBase<ProductDocument>
    {
        public string Name { get; private set; }

        public Product()
        {

        }

        public Product(Guid id, string name)
        {
            Id = id;
            Name = name;

            RaiseEvent(new ProductCreatedEvent(id, name));
        }

        public override void Load(ProductDocument document)
        {
            Id = document.Id;
            Version = document.Version;
            Name = document.Name;
            CreatedAt = document.CreatedAt;
            UpdatedAt = document.UpdatedAt;
        }

        public override ProductDocument ToDocument()
        {
            var productDocument = new ProductDocument
            {
                Id = Id,
                Name = Name
            };

            return productDocument;
        }
    }
}
