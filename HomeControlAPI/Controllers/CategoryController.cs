using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using ViewModels;
using System.Reflection;
using Microsoft.AspNetCore.Http;

namespace HomeControlAPI.Controllers 
    {
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase {

        private readonly ILogger _logger;


        // constructor
        public CategoryController(ILogger<CategoryController> logger) {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult GetAll() {
            try {
                CategoryViewModel viewmodel = new CategoryViewModel();
                List<CategoryViewModel> allDepartments = viewmodel.GetAll();
                return Ok(allDepartments);
            }
            catch (Exception ex) {
                _logger.LogError("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError); // something went wrong
            }
        }

    }
}
