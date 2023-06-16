using cmtech_backend.Models.Converter.Interfaces;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Models.Converter.Implementations
{
    public class DepartmentConverter : IParser<DepartmentDto, Department>, IParser<Department, DepartmentDto>
    {
        public Department Parse(DepartmentDto parser)
        {
            if (parser == null) throw new ArgumentNullException(nameof(parser));
            return new Department
            {
                Id = parser.Id,
                Name = parser.Name,
                Org_id = parser.Org_id,
            };
        }

        public List<Department> Parse(List<DepartmentDto> parser)
        {
            if (parser == null) throw new ArgumentNullException(nameof(parser));
            return parser.Select(department => Parse(department)).ToList();
        }
        public DepartmentDto Parse(Department parser)
        {
            if (parser == null) throw new ArgumentNullException(nameof(parser));
            return new DepartmentDto
            {
                Id = parser.Id,
                Name = parser.Name,
                Org_id = parser.Org_id,
                Org = parser.Org.Name
            };
        }

        public List<DepartmentDto> Parse(List<Department> parser)
        {
            if (parser == null) throw new ArgumentNullException(nameof(parser));
            return parser.Select(department => Parse(department)).ToList();
        }
    }
}
