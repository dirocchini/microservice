using System;

namespace Rocchini.Common.Events.Interfaces
{
    public interface IAuthenticatedEvent : IEvent
    {
        Guid UserId { get; }
    }
}
