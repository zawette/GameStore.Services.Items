using Application.Exceptions;
using Application.Services;
using Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
    {
        private readonly IItemRepository _repository;
        private readonly IEventProcessor _eventProcessor;

        public DeleteItemCommandHandler(IItemRepository repository, IEventProcessor eventProcessor)
        {
            _repository = repository;
            _eventProcessor = eventProcessor;
        }

        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetAsync(request.Id);
            if (item is null) { throw new ItemNotFoundException(request.Id); }
            await _repository.DeleteAsync(item.Id);
            await _eventProcessor.ProcessAsync(item.Events);
            return Unit.Value;
        }
    }
}