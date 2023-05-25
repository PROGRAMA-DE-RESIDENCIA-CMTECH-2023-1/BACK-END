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
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet, Authorize]
        public async Task<List<Group>> FindAll()
        {
            return await _groupService.FindAll();
        }

        [HttpPost, Authorize(Roles = "Administrador")]
        public async Task<Group> Create(GroupDto createGroup)
        {
            return await _groupService.Create(createGroup);
        }

        [HttpPut, Authorize(Roles = "Administrador")]
        public async Task<Group> Update(GroupDto updateGroup)
        {
            return await _groupService.Update(updateGroup);
        }

        [HttpDelete, Authorize(Roles = "Administrador")]
        public async Task<List<Group>> Delete(int id)
        {
            return await _groupService.Delete(id);
        }
    }
}
