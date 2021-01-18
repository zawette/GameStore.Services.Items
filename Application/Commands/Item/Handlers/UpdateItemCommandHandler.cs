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
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
    {
        private readonly IItemRepository _repository;
        private readonly IEventProcessor _eventProcessor;

        public UpdateItemCommandHandler(IItemRepository repository, IEventProcessor eventProcessor)
        {
            _repository = repository;
            _eventProcessor = eventProcessor;
        }

        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetAsync(request.Id);
            if (item is null) { throw new ItemNotFoundException(request.Id); }
            var updatedItem = Item.Update(item, request.Category, request.Name, request.Description, request.Tags, request.UnitPrice);
            await _repository.UpdateAsync(updatedItem);
            await _eventProcessor.ProcessAsync(updatedItem.Events);
            return Unit.Value;
        }
    }
}