using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cmtech_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SegmentController : ControllerBase
    {
        private readonly ISegmentService _segmentService;

        public SegmentController(ISegmentService segmentService)
        {
            _segmentService = segmentService;
        }

        [HttpGet]
        public async Task<List<Segment>> FindAll()
        {
            return await _segmentService.FindAll();
        }

        [HttpPost]
        public async Task<Segment> Create(CreateSegment createSegment)
        {
            return await _segmentService.Create(createSegment);
        }

        [HttpPut]
        public async Task<Segment> Update(int id, CreateSegment updateSegment)
        {
            return await _segmentService.Update(id, updateSegment);
        }

        [HttpDelete]
        public async Task<List<Segment>> Delete(int id)
        {
            return await _segmentService.Delete(id);
        }
    }
}
