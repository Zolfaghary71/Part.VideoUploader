using MediatR;
using Microsoft.AspNetCore.Http;

namespace Part.VideoUploader.Service.Features.UploadQueue.Command;

public class EnqueueVideoUploadCommand: IRequest<bool>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Extension { get; set; }
    public DateTime DateCreated { get; set; }
    
    public IFormFile File { get; set; }
}