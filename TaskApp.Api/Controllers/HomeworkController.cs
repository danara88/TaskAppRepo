using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskApp.Api.Responses;
using TaskApp.Core.DTOs;
using TaskApp.Core.Entities;
using TaskApp.Core.Inputs;
using TaskApp.Core.Interfaces.Services;

namespace TaskApp.Api.Controllers
{
    /// <summary>
    /// Homework controller
    /// </summary>
    [Authorize]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworkService _homeworkService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="homeworkService"></param>
        /// <param name="mapper"></param>
        public HomeworkController(IHomeworkService homeworkService, IMapper mapper)
        {
            _homeworkService = homeworkService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create homework endpoint
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/homeworks")]
        public async Task<ActionResult> CreateHomework([FromBody] HomeworkInput input)
        {
            var homework = _mapper.Map<Homework>(input);
            await _homeworkService.CreateHomework(homework);
            return Ok();
        }

        /// <summary>
        /// Get homeworks by user ID endpoint
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/homeworks/{userId}")]
        public async Task<ActionResult<DefaultResp<List<HomeworkDto>>>> GetHomeworks(int userId)
        {
            List<Homework> homeworks = await _homeworkService.GetHomeworksByUser(userId);
            var response = new DefaultResp<List<HomeworkDto>>(_mapper.Map<List<HomeworkDto>>(homeworks));
            return Ok(response);
        }

        /// <summary>
        /// Update homework endpoint
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/homeworks/{id}")]
        public async Task<ActionResult> UpdateHomework(int id,  UpdateHomeworkInput input)
        {
            var homework = _mapper.Map<Homework>(input);
            homework.Id = id;
            bool result = await _homeworkService.UpdateHomework(homework);
            if (!result) return BadRequest();
            return Ok();
        }

        /// <summary>
        /// Delete homework endpoint
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/homeworks/{id}")]
        public async Task<ActionResult> DeleteHomework(int id)
        {
            bool result = await _homeworkService.DeleteHomeworkById(id);
            if (!result) return BadRequest();
            return Ok();
        }

        /// <summary>
        /// Assign categories to a homework
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/homeworks/assign_categories")]
        public async Task<ActionResult> AssignCategoriesToHomework([FromBody] List<CategoryHomeworkInput> input)
        {
            var categoriesHomework = _mapper.Map<List<CategoryHomework>>(input);
            await _homeworkService.AssignCategoriesToHomework(categoriesHomework);
            return Ok();
        }
    }
}
