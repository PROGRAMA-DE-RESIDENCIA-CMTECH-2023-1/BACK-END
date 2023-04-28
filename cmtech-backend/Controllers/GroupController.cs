﻿using cmtech_backend.Models.Dtos;
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

        [HttpGet("/{name}")]
        public async Task<Group?> FindByName([FromRoute]string name)
        {
            return await _groupService.FindByName(name);
        }

        [HttpPost]
        public async Task<Group> Create(GroupDto createGroup)
        {
            return await _groupService.Create(createGroup);
        }

        [HttpPut]
        public async Task<Group> Update(GroupDto updateGroup)
        {
            return await _groupService.Update(updateGroup);
        }

        [HttpDelete]
        public async Task<List<Group>> Delete(int id)
        {
            return await _groupService.Delete(id);
        }
    }
}
