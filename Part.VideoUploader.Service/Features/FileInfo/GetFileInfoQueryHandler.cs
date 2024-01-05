using MediatR;
using Part.VideoUploader.Service.Contracts.Infrastructure;

namespace Part.VideoUploader.Service.Features.FileInfo;

public class GetFileInfoQueryHandler : IRequestHandler<GetFileInfoQuery, GetFileInfoResponse>
{
    private readonly IFileUploadInfoRepository _fileUploadInfoRepository;

    public GetFileInfoQueryHandler(IFileUploadInfoRepository fileUploadInfoRepository)
    {
        _fileUploadInfoRepository = fileUploadInfoRepository;
    }

    public async Task<GetFileInfoResponse> Handle(GetFileInfoQuery request, CancellationToken cancellationToken)
    {
        var res = await _fileUploadInfoRepository.GetFileUploadsByUserAsync(request.Id);
        return new GetFileInfoResponse() { fileUploadInfos = res };
    }
}