namespace TaskApp.Api.Responses
{
    /// <summary>
    /// Default API response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DefaultResp<T>
    {
        public DefaultResp(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}
