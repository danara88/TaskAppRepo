namespace TaskApp.Core.Exceptions
{
    /// <summary>
    /// Custom exception
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string message) : base(message)
        {
        }
    }
}
