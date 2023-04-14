using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Repositories.Interfaces;
using cmtech_backend.Services.Interfaces;

namespace cmtech_backend.Services.Implementations
{
    public class SegmentServiceImpl : ISegmentService
    {
        private readonly IRepository<Segment> _segmentRepository;

        public SegmentServiceImpl(IRepository<Segment> segmentRepository)
        {
            _segmentRepository = segmentRepository;
        }

        public async Task<Segment> Create(CreateSegment createSegment)
        {
            Segment segment = new Segment(createSegment.Name);
            return await _segmentRepository.Create(segment);
        }

        public async Task<List<Segment>> Delete(int id)
        {
            return await _segmentRepository.Delete(id);
        }

        public async Task<List<Segment>> FindAll()
        {
            return await _segmentRepository.FindAll();
        }

        public async Task<Segment> Update(int id, CreateSegment updateSegment)
        {
            Segment segment = new Segment(id, updateSegment.Name);
            return await _segmentRepository.Update(id, segment);
        }
    }
}
