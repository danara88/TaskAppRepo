namespace TaskApp.Core.Inputs
{
    /// <summary>
    /// Input to assign categories to a homework
    /// </summary>
    public class CategoryHomeworkInput
    {
        public int HomeworkId { get; set; }

        public int CategoryId { get; set; }
    }
}
