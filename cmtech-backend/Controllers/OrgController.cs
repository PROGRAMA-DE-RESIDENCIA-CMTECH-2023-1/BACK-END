using cmtech_backend.Exceptions;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cmtech_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrgController : ControllerBase
    {
        private readonly IOrgService _orgService;

        public OrgController(IOrgService orgService)
        {
            _orgService = orgService;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> FindAll()
        {
            return Ok(await _orgService.FindAll());
        }

        [HttpPost, Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create(OrgDto createOrg)
        {
            return Ok(await _orgService.Create(createOrg));
        }

        [HttpPut, Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Update(OrgDto updateOrg)
        {
            try
            {
                return Ok(await _orgService.Update(updateOrg));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete, Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _orgService.Delete(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }
    }
}
