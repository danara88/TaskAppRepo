namespace TaskApp.Infrastructure.Options
{
    /// <summary>
    /// Class to map password configurations
    /// </summary>
    public class PasswordOptions
    {
        /// <summary>
        /// Salt size
        /// </summary>
        public int SaltSize { get; set; }

        /// <summary>
        /// Key size
        /// </summary>
        public int KeySize { get; set; }

        /// <summary>
        /// Iterations
        /// </summary>
        public int Iterations { get; set; }
    }
}
