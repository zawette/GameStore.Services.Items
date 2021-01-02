using Application.Exceptions;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class DeleteItemCommand : IRequest
    {
        public Guid Id { get; }

        public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
        {
            private IRepositoryBase _repository;

            public DeleteItemCommandHandler(IRepositoryBase repository)
            {
                _repository = repository;
            }
            public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
            {
                var item = await _repository.GetAsync(request.Id);
                if (item is null) { throw new ItemNotFoundException(request.Id); }
                await _repository.DeleteAsync(item.Id);
                //send Events
                return Unit.Value;
            }
        }
    }
}
