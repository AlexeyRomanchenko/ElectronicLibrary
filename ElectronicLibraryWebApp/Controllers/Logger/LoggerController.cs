using ElectronicLibrary.Domain.Core.Library;
using ElectronicLibrary.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectronicLibraryWebApp.Controllers.Logger
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private ILoggerRepository<Log> _repository;
        public LoggerController(ILoggerRepository<Log> repository)
        {
            _repository = repository;
        }
        // GET: api/<LoggerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var logs = await _repository.GetAsync();
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
