using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Services.Interfaces
{
    public interface ISegmentService
    {
        public Task<List<Segment>> FindAll();

        public Task<Segment> Create(CreateSegment createSegement);

        public Task<Segment> Update(int id, CreateSegment updateSegment);

        public Task<List<Segment>> Delete(int id);
    }
}
