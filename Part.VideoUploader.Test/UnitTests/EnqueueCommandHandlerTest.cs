using Moq;
using Xunit;
using Part.VideoUploader.Domain;
using Part.VideoUploader.Service.Contracts.Infrastructure;
using Part.VideoUploader.Service.Features.UploadQueue;


namespace Part.VideoUploader.Test.UnitTests;

public class EnqueueCommandHandlerTest
{
    [Fact]
    public async void EnqueueCommandHandlerTest_ShouldEndqueue()
    {
        var video = new VideoFile()
        {
            Id = Guid.NewGuid(),
            Name = "videoName",
            Path = "videoPath",
            Type = "mp4",
            DateCreated = DateTime.Now
        };

        var redisRepo = new Mock<IRedisRepository<VideoFile>>();

        var commandHandler = new EnqueueCommandHandler();
        redisRepo.Setup(r => r.Set(video)).ReturnsAsync(true);
        
        redisRepo.Verify(s => s.Set(video), Times.Once);


    }
}