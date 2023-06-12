using InoversityLibrary.Application.Features.Documents.Commands;
using InoversityLibrary.Application.Features.Documents.Queries.GetAllDocuments;
using InoversityLibrary.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InoversityLibrary.Distribution.WebApi.Controllers;

public class DocumentsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public DocumentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<Result<List<DocumentsDtoResult>>>> GetAllDocuments()
    {
        var result = await _mediator.Send(new GetAllDocumentsQuery());
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<Result<int>>> AddDocument(CreateDocumentCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult<Result<int>>> DeleteDocument(int id)
    {
        var result = await _mediator.Send(DeleteDocumentCommand.Delete(id));
        return Ok(result);
    }
}