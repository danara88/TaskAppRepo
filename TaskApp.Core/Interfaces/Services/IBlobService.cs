namespace TaskApp.Core.Interfaces.Services
{
    /// <summary>
    /// Interface for azure blob service
    /// </summary>
    public interface IBlobService
    {
        /// <summary>
        /// Method to upload a file to blob storage container
        /// </summary>
        /// <param name="content"></param>
        /// <param name="extension"></param>
        /// <param name="container"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public Task<string> UploadFileAsync(byte[] content, string extension, string container, string contentType);

        /// <summary>
        /// Method to update a file from blob storage container
        /// </summary>
        /// <param name="content"></param>
        /// <param name="extension"></param>
        /// <param name="container"></param>
        /// <param name="path"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public Task<string> UpdateFileAsync(byte[] content, string extension, string container, string path, string contentType);

        /// <summary>
        /// Method to delete a file from blob storage container
        /// </summary>
        /// <param name="path"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public Task DeleteFileAsync(string path, string container);
    }
}
