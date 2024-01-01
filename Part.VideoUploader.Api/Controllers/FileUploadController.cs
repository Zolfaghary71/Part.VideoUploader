using System.Security.Claims;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using Part.VideoUploader.Service.Features.Upload.Commands;

namespace Part.VideoUploader.Api.Controllers;

[ApiController]
[Route("[controller]")]

public class FileUploadController : ControllerBase
{
    private readonly IMediator _mediator;

    public FileUploadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload()
    {
        var file = HttpContext.Request.Form.Files[0];
        if (file.Length == 0)
        {
            return BadRequest("Empty file received.");
        }

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var fileName = file.FileName;
        var contentType = file.ContentType;

        using (var stream = file.OpenReadStream())
        {
            var uploadId = await _mediator.Send(new UploadFileCommand(stream, fileName, contentType, userId));
            return Ok(new { UploadId = uploadId });
        }
    }
}
