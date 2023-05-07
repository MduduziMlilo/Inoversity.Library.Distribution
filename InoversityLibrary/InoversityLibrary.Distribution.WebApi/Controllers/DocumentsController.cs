using System.Collections.Generic;
using System.Threading.Tasks;
using InoversityLibrary.Application.Features.Documents.Commands;
using InoversityLibrary.Application.Features.Documents.Queries.GetAllDocuments;
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
        public async Task<ActionResult<Result<List<GetAllDocumentsDto>>>> Get()
        {
            return await _mediator.Send(new GetAllDocumentsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateDocumentCommand command)
        {
            return await _mediator.Send(command);
        }
}