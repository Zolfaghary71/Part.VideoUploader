using Part.VideoUploader.Service.Responses;

namespace Part.VideoUploader.Service.Features.Storage.Commands;

public class UploadFileCommandResponse:BaseResponse
{
    public UploadFileCommandResponse()
    {
        Success = true;
    }
    public UploadFileCommandResponse(string message):base(message)
    {
        Success = true;
        Message = message;
    }

    public UploadFileCommandResponse(string message, bool success):base(message,success)
    {
        Success = success;
        Message = message;
    }
}