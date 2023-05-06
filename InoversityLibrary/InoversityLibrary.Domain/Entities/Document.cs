using InoversityLibrary.Domain.Common;


namespace InoversityLibrary.Domain.Entities;

public class Document: BaseAuditableEntity
{
    public Document(string title, string author, string publisher)
    {
        Title = title;
        Author = author;
        Publisher = publisher;
    }

    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
}