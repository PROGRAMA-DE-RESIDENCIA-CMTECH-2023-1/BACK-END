using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Services.Interfaces;
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

        [HttpGet]
        public async Task<List<OrgDto>> FindAll()
        {
            return await _orgService.FindAll();
        }

        [HttpPost]
        public async Task<OrgDto> Create(OrgDto org)
        {
            return await _orgService.Create(org);
        }

        [HttpPut]
        public async Task<OrgDto> Update(OrgDto org)
        {
            return await _orgService.Update(org);
        }

        [HttpDelete]
        public async Task<List<Org>> Delete(int id)
        {
            return await _orgService.Delete(id);
        }
    }
}
