namespace Part.VideoUploader.Service.Features.UploadQueue.Command;

public class EnqueueVideoUploadCommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Path { get; set; }
    public DateTime DateCreated { get; set; }
}