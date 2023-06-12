using AutoMapper;
using InoversityLibrary.Application.Common.Mappings;
using InoversityLibrary.Application.Interfaces.Repositories;
using InoversityLibrary.Domain.Entities;
using InoversityLibrary.Shared;
using MediatR;

namespace InoversityLibrary.Application.Features.Documents.Commands;

public class CreateDocumentCommand : IRequest<Result<int>>, IMapFrom<Document>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public DateTime PublishedDate { get; set; }

    public static CreateDocumentCommand Create(Document document)
    {
        return new CreateDocumentCommand
        {
            Title = document.Title,
            Author = document.Author,
            Publisher = document.Publisher,
            PublishedDate = document.PublishedDate
        };
    }
}

internal class CreatedDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Result<int>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreatedDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(CreateDocumentCommand command, CancellationToken cancellationToken)
    {
        var document = Document.Create(command.Title,
            command.Author,
            command.Publisher,
            command.PublishedDate);

        await _unitOfWork.Repository<Document>().AddAsync(document);
        document.AddDomainEvent(DocumentCreatedEvent.Create(document));
        await _unitOfWork.Save(cancellationToken);
        return await Result<int>.SuccessAsync(document.Id, "Document Created.");
    }
}