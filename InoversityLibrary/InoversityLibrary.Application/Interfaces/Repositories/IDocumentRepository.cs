using System.Collections.Generic;
using System.Threading.Tasks;
using InoversityLibrary.Domain.Entities;

namespace InoversityLibrary.Application.Interfaces.Repositories;

public interface IDocumentRepository
{
    Task<List<Document>> GetDocumentsByAuthorAsync(int authorId);

}