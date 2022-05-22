using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.Services.Catalog.Dtos;
using Courses.Services.Catalog.Services;
using FreeCourse.Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : CustomBaseController
    {
        #region Props

        private readonly ICourseService _courseService;

        #endregion

        #region Ctor

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        #endregion


        #region Methods

        //courses/1

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var course = await _courseService.GetByIdAsync(id);

            return CreateActionResultInstance(course);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAllAsync();

            return CreateActionResultInstance(courses);
        }

        [Route("/api/[controller]/GetAllByUserId/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var courses = await _courseService.GetAllByUserIdAsync(userId);

            return CreateActionResultInstance(courses);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto request)
        {
            var result = await _courseService.CreateAsync(request);

            return CreateActionResultInstance(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto request)
        {
            var result = await _courseService.UpdateAsync(request);

            return CreateActionResultInstance(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _courseService.DeleteAsync(id);

            return CreateActionResultInstance(result);
        }

        #endregion
    }
}

