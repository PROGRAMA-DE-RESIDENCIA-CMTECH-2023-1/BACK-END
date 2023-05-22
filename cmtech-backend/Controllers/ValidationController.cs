using cmtech_backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cmtech_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidationController : ControllerBase
    {
        private readonly IValidationService _validationService;

        public ValidationController(IValidationService validationService)
        {
            _validationService = validationService;
        }

        [HttpGet]
        public async Task<IActionResult> Validate(string token)
        {
            return Ok(await _validationService.Validate(token));
        }
    }
}
