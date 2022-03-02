using TaskApp.Core.Enumerations;

namespace TaskApp.Core.DTOs
{
    /// <summary>
    /// Homework DTO
    /// </summary>
    public class HomeworkDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public HomeworkStatusEnum Status{ get; set; }
    }
}
