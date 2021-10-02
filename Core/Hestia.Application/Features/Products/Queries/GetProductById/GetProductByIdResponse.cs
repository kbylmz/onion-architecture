using Hestia.Domain.Models;
using System;

namespace Hestia.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public GetProductByIdResponse(Product product)
        {
            Id = product.Id;
            Name = product.Name;
        }
    }
}
