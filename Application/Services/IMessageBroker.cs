using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Events;

namespace Application.Services
{
    public interface IMessageBroker
    {
        Task PublishAsync(params IEvent[] events);
        Task PublishAsync(IEnumerable<IEvent> events);
    }
}
