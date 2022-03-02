using TaskApp.Core.Enumerations;

namespace TaskApp.Core.Inputs
{
    /// <summary>
    /// Homework input
    /// </summary>
    public class HomeworkInput
    {
        public int UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public HomeworkStatusEnum Status { get; set; }
    }
}
