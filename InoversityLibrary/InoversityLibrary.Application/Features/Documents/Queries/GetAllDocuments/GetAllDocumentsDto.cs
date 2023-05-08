using System;
using InoversityLibrary.Application.Common.Mappings;
using InoversityLibrary.Domain.Entities;

namespace InoversityLibrary.Application.Features.Documents.Queries.GetAllDocuments;

public class GetAllDocumentsDto: IMapFrom<Document>
{
    public static GetAllDocumentsDto Create(int id, string title, string author, string publisher, DateTime publishedDate)
    {
        return new GetAllDocumentsDto
        {
            Id = id,
            Title = title,
            Author = author,
            Publisher = publisher,
            PublishedDate = publishedDate,
        };
    }

    public int Id { get; init; }
    public string Title { get; init; }
    public string Author { get; init; }
    public string Publisher { get; init; }
    public DateTime PublishedDate { get; init; }
}