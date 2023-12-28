using Moq;
using Part.VideoUploader.Infrastructure.Storage;
using Part.VideoUploader.Service.Contracts.Infrastructure;
using Part.VideoUploader.Service.Features.Storage.Commands;
using Xunit;

namespace Part.VideoUploader.Test.UnitTests;

public class StorageServiceTests
{
    [Fact]
    public async Task SaveToStorage()
    {
        var mockMinioClient = new Mock<IStorageService>();

        var handler = new UploadFileCommandHandler(mockStorageService.Object);
        var command = new UploadFileCommand("/path/to/file.mp4", "file.mp4");

        // Act
        await handler.Handle(command, new CancellationToken());

        // Assert
        mockStorageService.Verify(s => s.UploadFileAsync("/path/to/file.mp4", "file.mp4"), Times.Once);
    }
}