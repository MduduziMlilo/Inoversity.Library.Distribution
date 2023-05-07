using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InoversityLibrary.Domain.Entities;
using InoversityLibrary.Application.Interfaces.Repositories;

namespace InoversityLibrary.DataAccess.Repositories;

public class DocumentRepository: IDocumentRepository
{
    private readonly IGenericRepository<Document> _repository;

    public DocumentRepository(IGenericRepository<Document> repository) 
    {
        _repository = repository;
    }

    public async Task<List<Document>> GetDocumentsByAuthorAsync(int authorId)
    {
        throw new NotImplementedException();
    }
    
}