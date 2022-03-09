using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Options;
using TaskApp.Core.Interfaces.Services;

namespace TaskApp.Infrastructure.AzureServices
{
    /// <summary>
    /// Class for azure blob service
    /// </summary>
    public class BlobService : IBlobService
    {
        private readonly AzureBlobSettings _azureBlobSettings;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="azureBlobSettings"></param>
        public BlobService(IOptions<AzureBlobSettings> azureBlobSettings)
        {
            _azureBlobSettings = azureBlobSettings.Value;
        }

        /// <summary>
        /// Method to delete a file from blob storage container
        /// </summary>
        /// <param name="path"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public async Task DeleteFileAsync(string path, string container)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            var client = new BlobContainerClient(_azureBlobSettings.StorageAccountKey, container);
            await client.CreateIfNotExistsAsync();
            var file = Path.GetFileName(path);
            var blob = client.GetBlobClient(file);
            await blob.DeleteIfExistsAsync();
        }

        /// <summary>
        /// Method to update a file from blob storage container
        /// </summary>
        /// <param name="content"></param>
        /// <param name="extension"></param>
        /// <param name="container"></param>
        /// <param name="path"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public async Task<string> UpdateFileAsync(byte[] content, string extension, string container, string path, string contentType)
        {
            await DeleteFileAsync(path, container);
            return await UploadFileAsync(content, extension, container, contentType);
        }

        /// <summary>
        /// Method to upload a file to blob storage container
        /// </summary>
        /// <param name="content"></param>
        /// <param name="extension"></param>
        /// <param name="container"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public async Task<string> UploadFileAsync(byte[] content, string extension, string container, string contentType)
        {
            var client = new BlobContainerClient(_azureBlobSettings.StorageAccountKey, container);
            await client.CreateIfNotExistsAsync();

            client.SetAccessPolicy(PublicAccessType.Blob);

            var fileName = $"{Guid.NewGuid()}{extension}";
            var blob = client.GetBlobClient(fileName);

            var blobUploadOptions = new BlobUploadOptions();
            var blobHttpHeader = new BlobHttpHeaders();
            blobHttpHeader.ContentType = contentType;
            blobUploadOptions.HttpHeaders = blobHttpHeader;

            await blob.UploadAsync(new BinaryData(content), blobUploadOptions);
            return blob.Uri.ToString();
        }
    }
}
