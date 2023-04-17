using cmtech_backend.Models.Converter.Interfaces;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Models.Converter.Implementations
{
    public class GroupConverter : IParser<GroupDto, Group>, IParser<Group, GroupDto>
    {
        public Group Parse(GroupDto parser)
        {
            if (parser == null) throw new ArgumentNullException();
            return new Group
            {
                Id = parser.Id,
                Name = parser.Name,
            };
        }

        public List<Group> Parse(List<GroupDto> parser)
        {
            if (parser == null || parser.Count == 0) throw new ArgumentNullException();
            return parser.Select(group => Parse(group)).ToList();
        }

        public GroupDto Parse(Group parser)
        {
            if (parser == null) throw new ArgumentNullException();
            return new GroupDto
            {
                Id = parser.Id,
                Name = parser.Name,
            };
        }

        public List<GroupDto> Parse(List<Group> parser)
        {
            if (parser == null || parser.Count == 0) throw new ArgumentNullException();
            return parser.Select(group => Parse(group)).ToList();
        }
    }
}
