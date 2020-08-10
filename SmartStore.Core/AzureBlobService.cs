using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using SmartStore.Core.Enum;

namespace SmartStore.Core
{
    public interface IAzureBlobService
    {
        Task<string> UploadBase64ToBlobNew(string fileName, BlobContainerEnum blobContainerName, byte[] fileBytes, string connectionString);
    }

    public class AzureBlobService : IAzureBlobService
    {
        public Microsoft.Extensions.Configuration.IConfiguration _config { get; }

        public AzureBlobService(Microsoft.Extensions.Configuration.IConfiguration  config)
        {
            _config = config;
        }

        public async Task<string> UploadBase64ToBlobNew(string fileName, BlobContainerEnum blobContainerName, byte[] fileBytes, string connectionString)
        {

            var conntd = _config.GetConnectionString("StorageConnectionstring"); 
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(blobContainerName.ToString().ToLower().Replace("_", ""));

            await container.CreateIfNotExistsAsync(BlobContainerPublicAccessType.Blob, null, null);

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
            await blockBlob.UploadFromByteArrayAsync(fileBytes, 0, fileBytes.Length);

            return blockBlob.Uri.AbsoluteUri;
        }
    }
}
