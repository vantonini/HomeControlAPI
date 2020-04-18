using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using ViewModels;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using HomeControlDAL;

namespace HomeControlAPI.Controllers 
    {
    
    [ApiController]
    public class TransactionController : ControllerBase {

        private readonly ILogger _logger;
        private readonly HomeControlContext _context;


        // constructor
        public TransactionController(ILogger<CategoryController> logger, HomeControlContext context) {
            _logger = logger;
            _context = context;
        }

        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult GetAll() {
            try {
                TransactionViewModel viewmodel = new TransactionViewModel(_context);
                List<TransactionViewModel> allElements = viewmodel.GetAll();
                return Ok(allElements);
            }
            catch (Exception ex) {
                _logger.LogError("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError); // something went wrong
            }
        }

        [Route("api/transactions/upload")]
        [HttpPost]
        public IActionResult Upload(List<TransactionViewModel> listVM) {
            try {
                foreach (TransactionViewModel vm in listVM) {
                    vm.Add();
                }
                return Ok();    
            }
            catch (Exception ex) {
                _logger.LogError("Problem in " + GetType().Name + " " +
                    MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError); // something went wrong

            }
        }

    }
}
