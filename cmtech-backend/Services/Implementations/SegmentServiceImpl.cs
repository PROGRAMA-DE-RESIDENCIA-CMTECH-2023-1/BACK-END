using cmtech_backend.Models.Converter.Implementations;
using cmtech_backend.Models.Converter.Interfaces;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Repositories.Interfaces;
using cmtech_backend.Services.Interfaces;

namespace cmtech_backend.Services.Implementations
{
    public class SegmentServiceImpl : ISegmentService
    {
        private readonly IRepository<Segment> _segmentRepository;

        private readonly SegmentConverter _converter;

        public SegmentServiceImpl(IRepository<Segment> segmentRepository)
        {
            _segmentRepository = segmentRepository;
            _converter = new SegmentConverter();
        }

        public async Task<Segment> Create(SegmentDto createSegment)
        {
            Segment segment = _converter.Parse(createSegment);
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

        public async Task<Segment> Update(SegmentDto updateSegment)
        {
            Segment segment = _converter.Parse(updateSegment);
            return await _segmentRepository.Update(segment);
        }
    }
}
