using cmtech_backend.Models.Converter.Interfaces;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Models.Converter.Implementations
{
    public class SegmentConverter : IParser<SegmentDto, Segment>, IParser<Segment, SegmentDto>
    {
        public Segment Parse(SegmentDto parser)
        {
            if (parser == null) throw new ArgumentNullException();
            return new Segment
            {
                Id = parser.Id,
                Name = parser.Name,
            };
        }

        public List<Segment> Parse(List<SegmentDto> parser)
        {
            if (parser == null || parser.Count == 0) throw new ArgumentNullException();
            return parser.Select(segment => Parse(segment)).ToList();
        }

        public SegmentDto Parse(Segment parser)
        {
            if (parser == null) throw new ArgumentNullException();
            return new SegmentDto
            {
                Id = parser.Id,
                Name = parser.Name,
            };
        }

        public List<SegmentDto> Parse(List<Segment> parser)
        {
            if (parser == null || parser.Count == 0) throw new ArgumentNullException();
            return parser.Select(segment => Parse(segment)).ToList();
        }
    }
}
