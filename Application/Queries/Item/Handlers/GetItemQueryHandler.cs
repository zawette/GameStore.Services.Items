using Application.DTO;
using Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Handlers
{
    public class GetItemQueryHandler : IRequestHandler<GetItemQuery, ItemDTO>
    {
        private readonly IItemRepository _repository;

        public GetItemQueryHandler(IItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<ItemDTO> Handle(GetItemQuery request, CancellationToken cancellationToken)
        {
            var Item = await _repository.GetAsync(request.Id);
            return Item.asItemDTO();
        }
    }
}