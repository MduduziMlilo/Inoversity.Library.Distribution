namespace InoversityLibrary.Domain.Common.Interfaces;

public interface IDomainEnventDispatcher
{
    Task DispatchAndClearEvents(IEnumerable<BaseEntity> entitiesWithEvents);
}