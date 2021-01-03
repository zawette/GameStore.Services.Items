using Application.Exceptions;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateItemCommand : IRequest
    {
        public Guid Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public IEnumerable<string> Tags { get; set; }

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
                request.Id = request.Id == Guid.Empty ? Guid.NewGuid() : request.Id;
                var item = Item.Create(request.Id, request.Category, request.Name, request.Description, request.Tags, request.UnitPrice);
                await _repository.AddAsync(item);
                //submit events later
                return Unit.Value;
            }
        }
    }
}