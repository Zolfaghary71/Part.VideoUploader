using Part.VideoUploader.Service.Contracts.Infrastructure;
using Minio;

using Minio.DataModel.Args;



namespace Part.VideoUploader.Infrastructure.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IMinioClient _minioClient;
        private readonly string _bucketName;

        public StorageService(string endpoint, string accessKey, string secretKey, string bucketName)
        {
            _minioClient = new MinioClient()
                .WithEndpoint(endpoint)
                .WithCredentials(accessKey, secretKey)
                .Build();
            _bucketName = bucketName;
        }

        public async Task UploadAsync(string bucketName, string objectName, Stream dataStream, string contentType)
        {
            // Check if the bucket exists, and if not, create it
            bool found = await _minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(_bucketName));
            if (!found)
            {
                await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(_bucketName));
            }

            // Upload the stream to the specified bucket with the given object name
            await _minioClient.PutObjectAsync(
                new PutObjectArgs()
                    .WithBucket(_bucketName)
                    .WithObject(objectName)
                    .WithStreamData(dataStream)
                    .WithObjectSize(dataStream.Length)
                    .WithContentType(contentType)
            );
        }

        public Task UploadAsync(string bucketName, string nameAfterUpload, string localFilePath, string objectName)
        {
            throw new NotImplementedException();
        }
    }
}
