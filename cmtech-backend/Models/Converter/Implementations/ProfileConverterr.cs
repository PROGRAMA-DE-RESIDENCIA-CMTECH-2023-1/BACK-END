using cmtech_backend.Models.Converter.Interfaces;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Models.Converter.Implementations
{
    public class ProfileConverter : IParser<ProfileDto, Profile>, IParser<Profile, ProfileDto>
    {
        public Profile Parse(ProfileDto parser)
        {
            if (parser == null) throw new ArgumentNullException();
            return new Profile
            {
                Id = parser.Id,
                Name = parser.Name
            };
        }

        public List<Profile> Parse(List<ProfileDto> origin)
        {
            if (origin == null || origin.Count == 0) throw new ArgumentNullException();
            return origin.Select(profile => Parse(profile)).ToList();
        }

        public ProfileDto Parse(Profile parser)
        {
            if (parser == null) throw new ArgumentNullException();
            return new ProfileDto
            {
                Id = parser.Id,
                Name = parser.Name
            };
        }

        public List<ProfileDto> Parse(List<Profile> parser)
        {
            if (parser == null || parser.Count == 0) throw new ArgumentNullException();
            return parser.Select(profile => Parse(profile)).ToList();
        }
    }
}
