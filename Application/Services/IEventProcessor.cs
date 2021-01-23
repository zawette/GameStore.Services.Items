using Domain.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IEventProcessor
    {
        Task ProcessAsync(IEnumerable<IDomainEvent> events);
    }
}