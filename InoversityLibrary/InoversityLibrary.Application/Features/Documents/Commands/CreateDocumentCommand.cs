using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;

using InoversityLibrary.Shared;
using InoversityLibrary.Domain.Entities;
using InoversityLibrary.Application.Common.Mappings;
using InoversityLibrary.Application.Interfaces.Repositories;


namespace InoversityLibrary.Application.Features.Documents.Commands;

public class CreateDocumentCommand: IRequest<Result<int>>, IMapFrom<Document>
{
    public static CreateDocumentCommand Create(Document document)
    {
        return new CreateDocumentCommand()
        {
            Title = document.Title,
            Author = document.Author,
            Publisher = document.Publisher,
            PublishedDate = document.PublishedDate
        };
    }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public DateTime PublishedDate { get; set; }
}

internal class CreatedDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
 
    public CreatedDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper; 
    }
 
    public async Task<Result<int>> Handle(CreateDocumentCommand command, CancellationToken cancellationToken)
    {
        var document = Document.Create(title: command.Title,
            author: command.Author,
            publisher: command.Publisher,
            publishedDate: command.PublishedDate);

        await _unitOfWork.Repository<Document>().AddAsync(document);
        document.AddDomainEvent(DocumentCreatedEvent.Create(document));
        await _unitOfWork.Save(cancellationToken);
        return await Result<int>.SuccessAsync(document.Id, "Document Created.");
    }
}