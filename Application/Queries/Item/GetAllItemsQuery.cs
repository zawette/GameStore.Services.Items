using Application.DTO;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries
{
    public partial class GetAllItemsQuery : IRequest<IEnumerable<ItemDTO>>
    {
    }
}