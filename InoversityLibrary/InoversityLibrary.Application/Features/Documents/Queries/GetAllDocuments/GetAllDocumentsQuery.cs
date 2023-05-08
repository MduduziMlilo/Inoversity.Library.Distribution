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

public record GetAllDocumentsQuery : IRequest<Result<List<GetAllDocumentsDto>>>;

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
        // var documents = await _unitOfWork.Repository<Document>().Entities
        //     .ProjectTo<GetAllDocumentsDto>(_mapper.ConfigurationProvider)
        //     .ToListAsync(cancellationToken);
        var documents = GetAllDocumentsDto.Create(id: 1,
            title: "My Title",
            author: "Sea Oater",
            publisher: "My Publisher",
            publishedDate: DateTime.UtcNow );
        List<GetAllDocumentsDto> docs = new List<GetAllDocumentsDto>() {documents };

        return await Result<List<GetAllDocumentsDto>>.SuccessAsync(docs);
    }
    
}