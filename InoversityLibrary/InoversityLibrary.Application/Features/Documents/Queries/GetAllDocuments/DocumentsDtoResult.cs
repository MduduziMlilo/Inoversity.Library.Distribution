using InoversityLibrary.Application.Common.Mappings;
using InoversityLibrary.Domain.Entities;

namespace InoversityLibrary.Application.Features.Documents.Queries.GetAllDocuments;

public class DocumentsDtoResult : IMapFrom<Document>
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string Author { get; init; }
    public string Publisher { get; init; }
    public DateTime PublishedDate { get; init; }

    public static DocumentsDtoResult Create(int id, string title, string author, string publisher,
        DateTime publishedDate)
    {
        return new DocumentsDtoResult
        {
            Id = id,
            Title = title,
            Author = author,
            Publisher = publisher,
            PublishedDate = publishedDate
        };
    }
}