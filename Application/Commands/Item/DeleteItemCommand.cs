using MediatR;
using System;

namespace Application.Commands
{
    public class DeleteItemCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}