using cmtech_backend.Models.Dtos;
using cmtech_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cmtech_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController: ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            return Ok(await _departmentService.FindAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentDto departmentDto)
        {
            return Ok(await _departmentService.Create(departmentDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(DepartmentDto departmentDto)
        {
            return Ok(await _departmentService.Update(departmentDto));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _departmentService.Delete(id));
        }
    }
}
