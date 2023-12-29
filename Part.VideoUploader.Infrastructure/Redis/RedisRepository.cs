using Microsoft.Extensions.Caching.Distributed;
using Part.VideoUploader.Domain;
using Part.VideoUploader.Service.Contracts.Infrastructure;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Part.VideoUploader.Infrastructure.Redis
{
    public class RedisRepository : IRedisRepository<VideoFile>
    {
        private readonly IDistributedCache _cache;

        public RedisRepository(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<VideoFile> Get(Guid id)
        {
            var cachedData = await _cache.GetAsync(id.ToString());
            if (cachedData == null)
            {
                return null;
            }

            return JsonSerializer.Deserialize<VideoFile>(cachedData);
        }

        public async Task<bool> Set(VideoFile videoFile)
        {
            var jsonData = JsonSerializer.SerializeToUtf8Bytes(videoFile);
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24)
            };

            await _cache.SetAsync(videoFile.Id.ToString(), jsonData, options);
            return true;
        }

        public async Task<bool> Delete(string id)
        {
            await _cache.RemoveAsync(id);
            return true;
        }
    }
}