namespace TaskApp.Infrastructure.AzureServices
{
    /// <summary>
    /// Class for azure blob settings
    /// </summary>
    public class AzureBlobSettings
    {
        /// <summary>
        /// Storage account key
        /// </summary>
        public string StorageAccountKey { get; set; }

        /// <summary>
        /// User image container
        /// </summary>
        public string UserFolder { get; set; }
    }
}
