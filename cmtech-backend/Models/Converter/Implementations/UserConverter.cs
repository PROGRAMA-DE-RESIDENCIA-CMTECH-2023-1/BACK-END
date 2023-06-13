using cmtech_backend.Models.Converter.Interfaces;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using Microsoft.AspNetCore.Identity;
using System;

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
                Password = BCrypt.Net.BCrypt.HashPassword(parser.Password),
                Profile_id = parser.ProfileId,
                Department_id = parser.DepartmentId,
                DateRegister = DateTime.UtcNow
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
                Org = parser.Org?.Name,
                OrgId = parser.Org_id,
                Profile = parser.Profile.Name,
                ProfileId = parser.Profile_id,
                Department = parser.Department?.Name,
                DepartmentId = parser.Department_id,
            };
        }

        public List<UserDto> Parse(List<User> parser)
        {
            if (parser == null) throw new ArgumentNullException();
            return parser.Select(user => Parse(user)).ToList();
        }
    }
}
