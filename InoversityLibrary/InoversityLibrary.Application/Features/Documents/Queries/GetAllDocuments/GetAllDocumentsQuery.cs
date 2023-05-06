using AutoMapper;
using AutoMapper.QueryableExtensions;
using InoversityLibrary.Application.Interfaces.Repositories;
using InoversityLibrary.Domain.Entities;
using InoversityLibrary.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InoversityLibrary.Application.Features.Documents.Queries.GetAllDocuments;

public abstract record GetAllDocumentsQuery : IRequest<Result<List<GetAllDocumentsDto>>>;

internal class GetAllDocumentsQueryHandler: IRequestHandler<GetAllDocumentsQuery, Result<List<GetAllDocumentsDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetAllDocumentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<Result<List<GetAllDocumentsDto>>> Handle(GetAllDocumentsQuery query, CancellationToken cancellationToken)
    { 
        var documents = await _unitOfWork.Repository<Document>().Entities
            .ProjectTo<GetAllDocumentsDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return await Result<List<GetAllDocumentsDto>>.SuccessAsync(documents);
    }
    
}