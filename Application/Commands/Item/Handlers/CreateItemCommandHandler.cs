using Application.Exceptions;
using Application.Services;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Handlers
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand>
    {
        private readonly IItemRepository _repository;
        private readonly IEventProcessor _eventProcessor;

        public CreateItemCommandHandler(IItemRepository repository, IEventProcessor eventProcessor)
        {
            _repository = repository;
            _eventProcessor = eventProcessor;
        }

        public async Task<Unit> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.ExistsAsync(request.Id)) { throw new ItemAlreadyExistsException(request.Id); }
            request.Id = request.Id == Guid.Empty ? Guid.NewGuid() : request.Id;
            var item = Item.Create(request.Id, request.Category, request.Name, request.Description, request.Tags, request.UnitPrice);
            await _repository.AddAsync(item);
            await _eventProcessor.ProcessAsync(item.Events);
            return Unit.Value;
        }
    }
}