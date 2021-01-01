using Application.Exceptions;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateItemCommand : IRequest
    {
        public Guid Id { get; }
        public Guid CategoryId { get; }
        public string Name { get; }
        public string Description { get; }
        public IEnumerable<string> Tags { get; }

        public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand>
        {
            private readonly IItemRepository _repository;

            public CreateItemCommandHandler(IItemRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(CreateItemCommand request, CancellationToken cancellationToken)
            {
                if (await _repository.ExistsAsync(request.Id)) { throw new ItemAlreadyExistsException(request.Id); }
                var item = Item.Create(request.Id, request.CategoryId, request.Name, request.Description, request.Tags);
                await _repository.AddAsync(item);
                //submit events later
                return Unit.Value;
            }
        }
    }
}