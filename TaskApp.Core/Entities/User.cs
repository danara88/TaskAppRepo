using Microsoft.EntityFrameworkCore;
using TaskApp.Core.Enumerations;

namespace TaskApp.Core.Entities
{
    /// <summary>
    /// User entity
    /// </summary>
    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User : BaseEntity
    {
        /// <summary>
        /// User's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User's surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// User's unique username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User's email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User's password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// user's role
        /// </summary>
        public RoleTypeEnum Role { get; set; }

        /// <summary>
        /// User's profile picture
        /// </summary>
        public string? Img { get; set; }

        /// <summary>
        /// Verify if it is deleted or not
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Creation time
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Last updated date
        /// </summary>
        public DateTime? LastUpdatedOn { get; set; }
    }
}
