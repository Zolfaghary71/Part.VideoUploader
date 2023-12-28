using MediatR;

namespace Part.VideoUploader.Service.Features.Storage.Commands;

public class UploadFileCommandHandler: IRequestHandler<UploadFileCommand, UploadFileCommandResponse>
{
    public Task<UploadFileCommandResponse> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}