using System.Collections.Generic;
using System.Threading.Tasks;
using InoversityLibrary.Application.Features.Documents.Commands;
using InoversityLibrary.Application.Features.Documents.Queries.GetAllDocuments;
using InoversityLibrary.Application.Interfaces.Repositories;
using InoversityLibrary.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InoversityLibrary.Distribution.WebApi.Controllers;

public class DocumentsController: ApiControllerBase
{
    private readonly IMediator _mediator;

        public DocumentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<DocumentsDtoResult>>>> Get()
        {
            var result = await _mediator.Send(new GetAllDocumentsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateDocumentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            var result = await _mediator.Send(DeleteDocumentCommand.Delete(id));
            return Ok(result);
        }
}