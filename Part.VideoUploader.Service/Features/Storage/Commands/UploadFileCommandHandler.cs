using MediatR;
using Part.VideoUploader.Service.Contracts.Infrastructure;
using Microsoft.Extensions.Logging;
namespace Part.VideoUploader.Service.Features.Storage.Commands;

public class UploadFileCommandHandler: IRequestHandler<UploadFileCommand, UploadFileCommandResponse>
{
    public IStorageService _storageService { get; set; }
    public ILogger _logger { get; set; }

    public UploadFileCommandHandler(IStorageService storageService, ILogger logger)
    {
        _storageService = storageService;
        _logger = logger;
    }

    public async Task<UploadFileCommandResponse> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        try
        {
           await _storageService.UploadAsync(request.BucketName, request.NameAfterUpload, request.FilePath, request.FileName);
           return new UploadFileCommandResponse("Upload Success");
        }
        catch (Exception e)
        {
            _logger.LogError("Failed to upload The File,InternalError. {0}",e.Message);
            return new UploadFileCommandResponse("Failed to upload The File,InternalError",false);
        }
    }
}