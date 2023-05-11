using InoversityLibrary.Domain.Common;
using InoversityLibrary.Domain.Entities;

namespace InoversityLibrary.Application.Features.Documents.Commands;


public class DocumentDeletedEvent : BaseEvent
{
    public Document Document { get; }

    public DocumentDeletedEvent(Document document)
    {
        Document = document;
    }
}
