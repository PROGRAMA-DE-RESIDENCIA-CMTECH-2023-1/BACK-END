using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Services.Interfaces
{
    public interface ISegmentService
    {
        public Task<List<Segment>> FindAll();

        public Task<Segment> Create(SegmentDto createSegement);

        public Task<Segment> Update(SegmentDto updateSegment);

        public Task<List<Segment>> Delete(int id);
    }
}
