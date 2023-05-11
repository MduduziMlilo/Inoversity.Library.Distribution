using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using InoversityLibrary.Application.Interfaces.Repositories;
using InoversityLibrary.Domain.Entities;
using InoversityLibrary.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InoversityLibrary.Application.Features.Documents.Queries.GetAllDocuments;

public record GetAllDocumentsQuery : IRequest<Result<List<DocumentsDtoResult>>>;

internal class GetAllDocumentsQueryHandler: IRequestHandler<GetAllDocumentsQuery, Result<List<DocumentsDtoResult>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetAllDocumentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<Result<List<DocumentsDtoResult>>> Handle(GetAllDocumentsQuery query, CancellationToken cancellationToken)
    { 
        var documents = await _unitOfWork.Repository<Document>().Entities
            .ProjectTo<DocumentsDtoResult>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        
        return await Result<List<DocumentsDtoResult>>.SuccessAsync(documents);
    }
    
}