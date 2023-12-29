using Moq;
using Xunit;
using Part.VideoUploader.Domain;
using Part.VideoUploader.Service.Contracts.Infrastructure;
using Part.VideoUploader.Service.Features.UploadQueue;
using Part.VideoUploader.Service.Features.UploadQueue.Command;


namespace Part.VideoUploader.Test.UnitTests;

public class EnqueueCommandHandlerTest
{
    [Fact]
    public async Task EnqueueCommandHandlerTest_ShouldEndqueue()
    {
        var video = new EnqueueVideoUploadCommand()
        {
            Id = Guid.NewGuid(),
            Name = "videoName",
            Path = "videoPath",
            Type = "mp4",
            DateCreated = DateTime.Now
        };

        var queue = new Mock<IQueue<EnqueueVideoUploadCommand>>();
        queue.Setup(q => q.EnqueueAsync(video)).Returns(Task.CompletedTask);
        var commandHandler = new EnqueueVideoUploadCommandHandler(queue.Object);
       await commandHandler.Handle(video,new CancellationToken());
       queue.Verify(s => s.EnqueueAsync(video), Times.Once);
    }
}