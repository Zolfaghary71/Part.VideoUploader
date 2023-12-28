namespace Part.VideoUploader.Service.Contracts.Infrastructure;

public interface IStorageService
{
   Task UploadAsync(string bucketName, string nameAfterUpload, string localFilePath, string objectName);
}