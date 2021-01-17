using Application.DTO;
using Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Handlers
{
    public partial class GetAllItemsQuery
    {
        public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, IEnumerable<ItemDTO>>
        {
            private IItemRepository _repository;

            public GetAllItemsQueryHandler(IItemRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<ItemDTO>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
            {
                var Items = await _repository.GetAllAsync();
                return Items.Select(i => i.asItemDTO());
            }
        }
    }
}