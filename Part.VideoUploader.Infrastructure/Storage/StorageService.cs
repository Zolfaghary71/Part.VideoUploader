using Part.VideoUploader.Service.Contracts.Infrastructure;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;

namespace Part.VideoUploader.Infrastructure.Storage;

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

    public async Task UploadAsync(string bucketName, string nameAfterUpload, string localFilePath, string objectName)
    {
        bool found = await _minioClient.BucketExistsAsync(
            new BucketExistsArgs()
                .WithBucket(_bucketName)
        );
        if (!found)
        {
            await _minioClient.MakeBucketAsync(
                new MakeBucketArgs()
                    .WithBucket(_bucketName)
            );
        }

        await _minioClient.PutObjectAsync(
            new PutObjectArgs()
                .WithBucket(_bucketName)
                .WithObject(objectName)
                .WithFileName(localFilePath)
                .WithContentType("Video")
        );
    }
}