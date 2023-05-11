using AutoMapper;
using InoversityLibrary.Application.Common.Mappings;
using InoversityLibrary.Application.Interfaces.Repositories;
using InoversityLibrary.Domain.Entities;
using InoversityLibrary.Shared;
using MediatR;

namespace InoversityLibrary.Application.Features.Documents.Commands;

public class DeleteDocumentCommand: IRequest<Result<int>>, IMapFrom<Document>
{
    public int Id { get; set; }

    public DeleteDocumentCommand()
    {

    }

    public static DeleteDocumentCommand Delete(int id)
    {
        return new DeleteDocumentCommand()
        {
            Id = id
        };
    }
}

internal class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(DeleteDocumentCommand command, CancellationToken cancellationToken)
    {
        var document = await _unitOfWork.Repository<Document>().GetByIdAsync(command.Id);
        
        if (document != null)
        {
            await _unitOfWork.Repository<Document>().DeleteAsync(document);
            document.AddDomainEvent(new DocumentDeletedEvent(document: document));

            await _unitOfWork.Save(cancellationToken);

            return await Result<int>.SuccessAsync(document.Id, "Document Deleted");
        }
        else
        {
            return await Result<int>.FailureAsync("Document Not Found.");
        }
    }
}