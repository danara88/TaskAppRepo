using Microsoft.AspNetCore.Mvc;
using TaskApp.Core.Enumerations;
using TaskApp.Core.Helpers;

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

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> CategoriesIDs { get; set; }
    }
}
