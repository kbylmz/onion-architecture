using MediatR;
using System;

namespace Hestia.Application.Features.Products.Commands.CreateProduct
{
    public partial class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
