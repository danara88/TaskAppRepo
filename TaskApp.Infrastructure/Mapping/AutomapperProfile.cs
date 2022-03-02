using AutoMapper;
using TaskApp.Core.DTOs;
using TaskApp.Core.Entities;
using TaskApp.Core.Inputs;

namespace TaskApp.Infrastructure.Mapping
{
    /// <summary>
    /// Class for automapper settings
    /// </summary>
    public class AutomapperProfile : Profile
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        public AutomapperProfile()
        {
            #region Homework
            CreateMap<HomeworkInput, Homework>();
            CreateMap<HomeworkDto, Homework>().ReverseMap();
            CreateMap<UpdateHomeworkInput, Homework>();
            #endregion Homework

            #region Category
            CreateMap<CategoryInput, Category>();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryInput, Category>();
            #endregion Category

            #region Security
            CreateMap<SecurityDto, User>();
            #endregion Security

            #region CategoryHomework
            CreateMap<CategoryHomeworkInput, CategoryHomework>();
            #endregion CategoryHomework
        }
    }
}
