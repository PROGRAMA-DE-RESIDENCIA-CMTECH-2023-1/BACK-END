using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cmtech_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<List<Group>> FindAll()
        {
            return await _groupService.FindAll();
        }

        [HttpPost]
        public async Task<Group> Create(CreateGroup createGroup)
        {
            return await _groupService.Create(createGroup);
        }

        [HttpPut]
        public async Task<Group> Update(int id, CreateGroup updateGroup)
        {
            return await _groupService.Update(id, updateGroup);
        }

        [HttpDelete]
        public async Task<List<Group>> Delete(int id)
        {
            return await _groupService.Delete(id);
        }
    }
}
