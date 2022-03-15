namespace TaskApp.Core.Entities
{
    /// <summary>
    /// Category entity
    /// </summary>
    public class Category : BaseEntity
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get; set; }

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
