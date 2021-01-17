using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Events;

namespace Application.Services
{
    public interface IEventProcessor
    {
        Task ProcessAsync(IEnumerable<IDomainEvent> events);

    }
}
