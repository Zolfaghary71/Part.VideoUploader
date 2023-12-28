using Moq;
using Xunit;

namespace Part.VideoUploader.Test.UnitTests;

public class StorageServiceTests
{
    [Fact]
    public async Task SaveToStorage()
    {
        var mockMinioClient = new Mock<IStorageWrapper>();
        var service = new StorageService(mockMinioClient.Object, "mybucket");

        string testFilePath = "testfile.mp4";
        string expectedObjectName = "testfile.mp4"; 

        await service.UploadFileAsync(testFilePath, expectedObjectName);

        mockMinioClient.Verify(client => client.PutObjectAsync("mybucket", expectedObjectName, testFilePath, "video/mp4"), Times.Once());
    }
}