using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskApp.Api.Responses;
using TaskApp.Core.DTOs;
using TaskApp.Core.Entities;
using TaskApp.Core.Enumerations;
using TaskApp.Core.Inputs;
using TaskApp.Core.Interfaces.Services;

namespace TaskApp.Api.Controllers
{
    /// <summary>
    /// Category controller
    /// </summary>
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="categoryService"></param>
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get categories endpoint
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("~/api/categories")]
        public DefaultResp<List<CategoryDto>> GetCategories()
        {
            var categories = _categoryService.GetCategories();
            return new DefaultResp<List<CategoryDto>>(_mapper.Map<List<CategoryDto>>(categories));
        }

        /// <summary>
        /// Method to create a category
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = nameof(RoleTypeEnum.Administrator))]
        [Route("~/api/categories")]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryInput input)
        {
            var category = _mapper.Map<Category>(input);
            await _categoryService.CreateCategory(category);
            return Ok();
        }

       /// <summary>
       /// Method to update a category
       /// </summary>
       /// <param name="id"></param>
       /// <param name="input"></param>
       /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = nameof(RoleTypeEnum.Administrator))]
        [Route("~/api/categories/{id}")]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryInput input)
        {
            var category = _mapper.Map<Category>(input);
            category.Id = id;
            bool result = await _categoryService.UpdateCategory(category);
            if (!result) return BadRequest();
            return Ok();
        }

        /// <summary>
        /// Method to delete a category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Roles = nameof(RoleTypeEnum.Administrator))]
        [Route("~/api/categories/{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            bool result = await _categoryService.DeleteCategoryById(id);
            if (!result) return BadRequest();
            return Ok();
        }
    }
}
