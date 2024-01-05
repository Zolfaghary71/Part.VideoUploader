using MediatR;
using Part.VideoUploader.Service.Responses;

namespace Part.VideoUploader.Service.Features.FileInfo;

public class GetFileInfoQuery:IRequest<GetFileInfoResponse>
{
    public string Id { get; set; }
}