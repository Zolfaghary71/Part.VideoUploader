using Moq;
using Xunit;
using Microsoft.Extensions.Caching.Distributed;
using Part.VideoUploader.Domain;
using Part.VideoUploader.Infrastructure.Redis;
using System.Text.Json;

namespace Part.VideoUploader.Test.UnitTests;

public class RedisRepositoryTests
{
    [Fact]
    public async Task Set_ShouldCacheVideoFile()
    {
        var mockCache = new Mock<IDistributedCache>();
        var repository = new RedisRepository(mockCache.Object);
        var videoFile = new VideoFile { Id = Guid.NewGuid()};

        await repository.Set(videoFile);

        mockCache.Verify(cache => cache.SetAsync(
            videoFile.Id.ToString(), 
            It.IsAny<byte[]>(), 
            It.IsAny<DistributedCacheEntryOptions>(),
            It.IsAny<System.Threading.CancellationToken>()), 
            Times.Once);
    }

    [Fact]
    public async Task Get_ShouldReturnVideoFile()
    {
        var videoFile = new VideoFile { Id = Guid.NewGuid()};
        var mockCache = new Mock<IDistributedCache>();
        var serializedVideoFile = JsonSerializer.SerializeToUtf8Bytes(videoFile);
        mockCache.Setup(m => m.GetAsync(videoFile.Id.ToString(), default))
                 .ReturnsAsync(serializedVideoFile);

        var repository = new RedisRepository(mockCache.Object);

        var result = await repository.Get(videoFile.Id);

        Assert.Equal(videoFile.Id, result.Id);
    }

    [Fact]
    public async Task Delete_ShouldRemoveVideoFile()
    {
        var videoFileId = Guid.NewGuid().ToString();
        var mockCache = new Mock<IDistributedCache>();
        var repository = new RedisRepository(mockCache.Object);

        await repository.Delete(videoFileId);

        mockCache.Verify(cache => cache.RemoveAsync(
            videoFileId, 
            It.IsAny<System.Threading.CancellationToken>()),
            Times.Once);
    }
}
