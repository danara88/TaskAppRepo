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
            #region User
            CreateMap<UpdateUserProfileInput, User>();
            #endregion User

            #region Homework
            CreateMap<HomeworkInput, Homework>()
                .ForMember(x => x.CategoriesHomeworks, options => options.MapFrom(MapCategoriesHomeworks));
            CreateMap<HomeworkDto, Homework>();
            CreateMap<Homework, HomeworkDto>()
                .ForMember(x => x.Categories, options => options.MapFrom(MapCategoriesInHomeworkDto));
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

        #region PrivateMethods

        /// <summary>
        /// Private method to map categoriesHomeworks
        /// </summary>
        /// <param name="input"></param>
        /// <param name="homework"></param>
        /// <returns></returns>
        private List<CategoryHomework> MapCategoriesHomeworks(HomeworkInput input, Homework homework)
        {
            var result = new List<CategoryHomework>();
            if (input.CategoriesIDs == null) return result;
            foreach (var categoryId in input.CategoriesIDs)
            {
                result.Add(new CategoryHomework { CategoryId = categoryId });
            }
            return result;
        }

        /// <summary>
        /// Private method to map categories in homeworkDtos
        /// </summary>
        /// <param name="homework"></param>
        /// <param name="homeworkDto"></param>
        /// <returns></returns>
        private List<CategoryDto> MapCategoriesInHomeworkDto(Homework homework, HomeworkDto homeworkDto)
        {
            var result = new List<CategoryDto>();
            if (homework.CategoriesHomeworks == null) return result;
            foreach (var categoryHomework in homework.CategoriesHomeworks)
            {
                result.Add(new CategoryDto() { Id = categoryHomework.Category.Id, Name = categoryHomework.Category.Name });
            }

            return result;
        }

        #endregion PrivateMethods
    }
}
