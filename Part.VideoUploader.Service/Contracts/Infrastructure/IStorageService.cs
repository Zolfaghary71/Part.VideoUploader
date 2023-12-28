namespace Part.VideoUploader.Service.Contracts.Infrastructure;

public interface IStorageService
{
   Task PutObjectAsync(string bucketName, string nameAfterUpload, string localFilePath, string objectName);
}