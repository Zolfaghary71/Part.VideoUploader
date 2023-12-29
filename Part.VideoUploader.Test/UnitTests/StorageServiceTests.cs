using Microsoft.Extensions.Logging;
using Moq;
using Part.VideoUploader.Infrastructure.Storage;
using Part.VideoUploader.Service.Contracts.Infrastructure;
using Part.VideoUploader.Service.Features.Storage.Commands;
using Xunit;

namespace Part.VideoUploader.Test.UnitTests;

public class StorageServiceTests
{
    [Fact]
    public async void SaveToStorage()
    {
        var storageService = new Mock<IStorageService>();
        var fileName = "file.mp4";
        var filePath = "/path/to/file.mp4";
        var bucketName = "defaultbucket";
        var handler = new UploadFileCommandHandler(storageService.Object, new Mock<ILogger<UploadFileCommandHandler>>().Object);
        var command = new UploadFileCommand(filePath, fileName);

        await handler.Handle(command, new CancellationToken());

        storageService.Verify(s => s.UploadAsync(bucketName, fileName,filePath,fileName), Times.Once);
    }
}