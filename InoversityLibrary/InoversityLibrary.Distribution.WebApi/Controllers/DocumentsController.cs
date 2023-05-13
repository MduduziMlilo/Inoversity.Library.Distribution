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

    [HttpGet("all")]
    public async Task<ActionResult<Result<List<DocumentsDtoResult>>>> GetAllDocuments()
    {
        var result = await _mediator.Send(new GetAllDocumentsQuery());
        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<ActionResult<Result<int>>> CreateDocument(CreateDocumentCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Result<int>>> DeleteDocument(int id)
    {
        var result = await _mediator.Send(DeleteDocumentCommand.Delete(id));
        return Ok(result);
    }
}