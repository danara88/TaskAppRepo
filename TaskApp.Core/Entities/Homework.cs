using TaskApp.Core.Enumerations;

namespace TaskApp.Core.Entities
{
    /// <summary>
    /// Task entity
    /// </summary>
    public class Homework : BaseEntity
    {
        /// <summary>
        /// User ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Task title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Task content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Task status
        /// </summary>
        public HomeworkStatusEnum Status { get; set; }

        /// <summary>
        /// Verify if it is deleted or not
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Navigation property
        /// </summary>
        public User User { get; set; }

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
