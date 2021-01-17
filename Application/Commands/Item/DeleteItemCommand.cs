using MediatR;
using System;

namespace Application.Commands
{
    public partial class DeleteItemCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}