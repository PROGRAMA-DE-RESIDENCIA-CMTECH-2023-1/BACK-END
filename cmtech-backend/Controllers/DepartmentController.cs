using cmtech_backend.Exceptions;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace cmtech_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> FindAll()
        {
            return Ok(await _departmentService.FindAll());
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Create(DepartmentDto createDepartment)
        {
            return Ok(await _departmentService.Create(createDepartment));
        }

        [HttpPut, Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Update(DepartmentDto updateDepartment)
        {
            try
            {
                return Ok(await _departmentService.Update(updateDepartment));
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
                return Ok(await _departmentService.Delete(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }
    }
}
