using Part.VideoUploader.Domain;

namespace Part.VideoUploader.Service.Features.FileInfo;

public class GetFileInfoResponse
{
    public IEnumerable<FileUploadInfo> fileUploadInfos { get; set; }
}