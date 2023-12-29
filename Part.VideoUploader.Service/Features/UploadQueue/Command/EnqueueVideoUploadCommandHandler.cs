using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Part.VideoUploader.Service.Contracts.Infrastructure;

namespace Part.VideoUploader.Service.Features.UploadQueue.Command;

public class EnqueueVideoUploadCommandHandler : IRequestHandler<EnqueueVideoUploadCommand, bool>
{
    private readonly IQueue<EnqueueVideoUploadCommand> _uploadQueue;

    public EnqueueVideoUploadCommandHandler(IQueue<EnqueueVideoUploadCommand> uploadQueue)
    {
        _uploadQueue = uploadQueue;
    }

    public async Task<bool> Handle(EnqueueVideoUploadCommand command, CancellationToken cancellationToken)
    {
        try
        {
            await _uploadQueue.EnqueueAsync(command);
            return true;
        }
        catch
        {
            return false;
        }
    }
}