using InoversityLibrary.Domain.Common;
using InoversityLibrary.Domain.Entities;

namespace InoversityLibrary.Application.Features.Documents.Commands;

public class DocumentCreatedEvent : BaseEvent
{
    public Document Document { get; set; }

    public static DocumentCreatedEvent Create(Document document)
    {
        return new DocumentCreatedEvent
        {
            Document = document
        };
    }
}