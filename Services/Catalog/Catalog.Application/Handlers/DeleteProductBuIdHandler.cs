using Catalog.Application.Commands;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class DeleteProductBuIdHandler : IRequestHandler<DeleteProductByIdCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductBuIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
    {
        return await _productRepository.DeleteProduct(request.Id);
    }
}
