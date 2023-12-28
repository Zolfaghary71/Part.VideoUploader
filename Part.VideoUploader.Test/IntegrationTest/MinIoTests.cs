using Part.VideoUploader.Infrastructure.Storage;
using Xunit;

namespace Part.VideoUploader.Test.IntegrationTest;

public class MinIoTests
{
    [Fact]
    public async void SaveToMinIo()
    {
        string minioEndpoint = "YourMinioEndpoint";
        string accessKey = "YourAccessKey";
        string secretKey = "YourSecretKey";
        string bucketName = "defaultbucket"; 
        var service = new StorageService(minioEndpoint, accessKey, secretKey, bucketName);

        string testFilePath = "path/to/local/testvideo.mp4"; 
        string objectName = "testvideo.mp4";
        string contentType = "video/mp4"; 

        await service.UploadAsync(bucketName, objectName, testFilePath,objectName);

    }
}