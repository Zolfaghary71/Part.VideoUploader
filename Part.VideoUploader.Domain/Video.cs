using System.IO.Enumeration;
using System.Security.Cryptography;

namespace Part.VideoUploader.Domain;

public class Video
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateCreated { get; set; }
    public VideoMetaData VideoMetaData { get; set; }
}