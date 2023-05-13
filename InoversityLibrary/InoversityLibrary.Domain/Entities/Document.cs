using InoversityLibrary.Domain.Common;

namespace InoversityLibrary.Domain.Entities;

public class Document : BaseAuditableEntity
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public DateTime PublishedDate { get; set; }

    public static Document Create(string title, string author, string publisher, DateTime publishedDate)
    {
        return new Document
        {
            Title = title,
            Author = author,
            Publisher = publisher,
            PublishedDate = publishedDate
        };
    }
}