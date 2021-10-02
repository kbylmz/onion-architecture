using Hestia.Application.Contracts.Readers;
using Hestia.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hestia.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Optional<GetProductByIdResponse>>
    {
        public Guid Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Optional<GetProductByIdResponse>>
        {
            private readonly IProductReader productReader;

            public GetProductByIdQueryHandler(IProductReader productReader)
            {
                this.productReader = productReader;
            }

            public async Task<Optional<GetProductByIdResponse>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await productReader.GetById(query.Id);

                if (product == null)
                {
                    return Optional<GetProductByIdResponse>.Empty;
                }

                var response = new GetProductByIdResponse(product);
                return new Optional<GetProductByIdResponse>(response);
            }
        }
    }
}
