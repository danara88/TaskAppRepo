namespace TaskApp.Core.Entities
{
    /// <summary>
    /// CategoryTask entity
    /// </summary>
    public class CategoryHomework : BaseEntity
    {
        /// <summary>
        /// Category ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Homework ID
        /// </summary>
        public int HomeworkId { get; set; }

        /// <summary>
        /// Category navigation property
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Task navigation property
        /// </summary>
        public Homework Homework { get; set; }
    }
}
