using MediatR;

namespace InoversityLibrary.Domain.Common;

public abstract class BaseEvent : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}