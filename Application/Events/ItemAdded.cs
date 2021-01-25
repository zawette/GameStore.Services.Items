using MediatR;
using System;

namespace Application.Events
{
    public class ItemAdded : IEvent, IRequest
    {
        public Guid Id { get; set; }

        public ItemAdded(Guid id)
        {
            Id = id;
        }
    }
}