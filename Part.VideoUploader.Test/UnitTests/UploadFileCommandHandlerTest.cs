
using Moq;
using Xunit;
using Microsoft.AspNetCore.Http;
using Part.VideoUploader.Service.Contracts.Infrastructure;
using Part.VideoUploader.Service.Features.Storage.Commands;

namespace Part.VideoUploader.Test.UnitTests;

public class UploadFileCommandHandlerTest
{
    [Fact]
    public async Task Handle_ShouldUploadFile_AndUpdateStatus()
    {
        var mockStorageService = new Mock<IStorageService>();
        var mockFileUploadService = new Mock<IFileUploadService>();
        var fileMock = new Mock<IFormFile>();
        var command = new UploadFileCommand(fileMock.Object, "testUserId");
        var handler = new UploadFileCommandHandler(mockStorageService.Object, mockFileUploadService.Object);

        var result = await handler.Handle(command, CancellationToken.None);

        mockStorageService.Verify(s => s.UploadAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Stream>(), It.IsAny<string>()), Times.Once);
        mockFileUploadService.Verify(s => s.TrackUploadAsync(It.IsAny<FileUploadInfo>()), Times.Once);
        mockFileUploadService.Verify(s => s.UpdateUploadStatusAsync(result, "Completed"), Times.Once);
        Assert.IsType<Guid>(result);
    }
}
