using InoversityLibrary.Domain.Common;
using InoversityLibrary.Domain.Entities;

namespace InoversityLibrary.Application.Features.Documents.Commands;

public class DocumentDeletedEvent : BaseEvent
{
    public DocumentDeletedEvent(Document document)
    {
        Document = document;
    }

    public Document Document { get; }
}