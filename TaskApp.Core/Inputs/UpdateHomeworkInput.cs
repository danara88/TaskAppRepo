using TaskApp.Core.Enumerations;

namespace TaskApp.Core.Inputs
{
    /// <summary>
    /// Input to update a homework
    /// </summary>
    public class UpdateHomeworkInput
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public HomeworkStatusEnum Status { get; set; }
    }
}
