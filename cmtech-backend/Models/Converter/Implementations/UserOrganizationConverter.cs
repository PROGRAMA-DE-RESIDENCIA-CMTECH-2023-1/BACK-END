using cmtech_backend.Models.Converter.Interfaces;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Models.Converter.Implementations
{
    public class UserOrganizationConverter : IParser<UserOrganizationDto, UserOrganization>, IParser<UserOrganization, UserOrganizationDto>
    {
        public UserOrganization Parse(UserOrganizationDto parser)
        {
            var userConverter = new UserConverter();
            var orgConverter = new OrgConverter();
            if (parser == null) throw new ArgumentNullException();
            return new UserOrganization
            {
                Id = parser.Id,
                UserId = parser.UserId,
                OrganizationId = parser.OrganizationId,
                User = userConverter.Parse(parser.User),
                Org = orgConverter.Parse(parser.Org),
            };
        }

        public List<UserOrganization> Parse(List<UserOrganizationDto> parser)
        {
            if (parser == null) throw new ArgumentNullException();
            return parser.Select(user => Parse(user)).ToList();
        }

        public UserOrganizationDto Parse(UserOrganization parser)
        {
            var userConverter = new UserConverter();
            var orgConverter = new OrgConverter();
            if (parser == null) throw new ArgumentNullException();
            return new UserOrganizationDto
            {
                Id = parser.Id,
                UserId = parser.UserId,
                OrganizationId = parser.OrganizationId,
                User = userConverter.Parse(parser.User),
                Org = orgConverter.Parse(parser.Org),
            };
        }

        public List<UserOrganizationDto> Parse(List<UserOrganization> parser)
        {
            if (parser == null) throw new ArgumentNullException();
            return parser.Select(user => Parse(user)).ToList();
        }
    
    }
}
