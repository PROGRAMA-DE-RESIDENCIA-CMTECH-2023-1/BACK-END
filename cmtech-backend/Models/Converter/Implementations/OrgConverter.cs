using cmtech_backend.Models.Converter.Interfaces;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Models.Converter.Implementations
{
    public class OrgConverter : IParser<OrgDto, Org>, IParser<Org, OrgDto>
    {
        public Org Parse(OrgDto parser)
        {
            if (parser == null) throw new ArgumentNullException(nameof(parser));
            return new Org
            {
                Id = parser.Id,
                Name = parser.Name,
                Phone = parser.Phone,
                Segment_id = parser.SegmentId,
                Group_id = parser.GroupId
            };
        }

        public List<Org> Parse(List<OrgDto> parser)
        {
            if (parser == null) throw new ArgumentNullException();
            return parser.Select(org => Parse(org)).ToList();
        }

        public OrgDto Parse(Org parser)
        {
            if (parser == null) throw new ArgumentNullException();
            return new OrgDto
            {
                Id = parser.Id,
                Name = parser.Name,
                Phone = parser.Phone,
                SegmentId = parser.Segment_id,
                Segment = parser.Segment.Name,
                GroupId = parser.Group_id,
                Group = parser.Group.Name
            };
        }

        public List<OrgDto> Parse(List<Org> parser)
        {
            if (parser == null) throw new ArgumentNullException();
            return parser.Select(org => Parse(org)).ToList();
        }
    }
}
