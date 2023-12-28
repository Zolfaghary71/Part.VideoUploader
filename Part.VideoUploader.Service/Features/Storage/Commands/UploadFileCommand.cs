using MediatR;

namespace Part.VideoUploader.Service.Features.Storage.Commands;

public class UploadFileCommand:IRequest<UploadFileCommandResponse>
{
    public string FilePath { get; set; }
    public string NameAfterUpload { get; set; }
    public string BucketName { get; set; }
    public string FileName { get; set; }

    public UploadFileCommand(string filePath,string fileName)
    {
        FilePath = filePath;
        FileName = fileName;
        NameAfterUpload = fileName;
        BucketName = "DefaultBucket";
    }
}