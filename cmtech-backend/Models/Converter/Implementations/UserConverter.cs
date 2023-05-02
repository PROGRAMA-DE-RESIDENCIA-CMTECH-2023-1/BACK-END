using cmtech_backend.Models.Converter.Interfaces;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Models.Converter.Implementations
{
    public class UserConverter : IParser<UserDto, User>, IParser<User, UserDto>
    {
        public User Parse(UserDto parser)
        {
            if (parser == null) throw new ArgumentNullException();
            return new User
            {
                Id = parser.Id,
                Name = parser.Name,
                Email = parser.Email,
                Org_id = parser.OrgId,
                Password = parser.Password,
                Profile_id = parser.ProfileId,
                DateRegister = DateTime.Now.ToString(),
            };
        }

        public List<User> Parse(List<UserDto> parser)
        {
            if (parser == null) throw new ArgumentNullException();
            return parser.Select(user =>  Parse(user)).ToList();
        }

        public UserDto Parse(User parser)
        {
            if (parser == null) throw new ArgumentNullException();
            return new UserDto
            {
                Id = parser.Id,
                Name = parser.Name,
                Email = parser.Email,
                Org = parser.Org.Name,
                OrgId = parser.Org_id,
                Password = parser.Password,
                DateRegister = parser.DateRegister,
                Profile = parser.Profile.Name,
                ProfileId = parser.Profile_id
            };
        }

        public List<UserDto> Parse(List<User> parser)
        {
            if (parser == null) throw new ArgumentNullException();
            return parser.Select(user => Parse(user)).ToList();
        }
    }
}
