using Microsoft.AspNetCore.Http;

namespace TaskApp.Core.Inputs
{
    /// <summary>
    /// Update user profile input
    /// </summary>
    public class UpdateUserProfileInput
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public IFormFile? Img { get; set; }
    }
}
