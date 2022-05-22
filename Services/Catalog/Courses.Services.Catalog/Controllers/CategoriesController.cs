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
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllAsync();

            return CreateActionResultInstance(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _categoryService.GetByIdAsync(id);

            return CreateActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto category)
        {
            var result = await _categoryService.CreateAsync(category);

            return CreateActionResultInstance(result);
        }

    }
}

