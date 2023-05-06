using InoversityLibrary.Application.Common.Mappings;
using InoversityLibrary.Domain.Entities;

namespace InoversityLibrary.Application.Features.Documents.Queries.GetAllDocuments;

public class GetAllDocumentsDto: IMapFrom<Document>
{
    public string Id { get; init; }
    public string Title { get; init; }
    public string Author { get; init; }
    public string Publisher { get; init; }
    public DateTime PublishedDate { get; init; }
}