using AutoMapper;
using Students.DTO;
using Students.Model;

namespace Students.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<StudentsModel, StudentDTO>().ReverseMap();
            CreateMap<StudentsModel, UpdateStudentDTO>().ReverseMap();
            CreateMap<AdminModel, AdminDetailsDTO>().ReverseMap();
            CreateMap<StudentsModel, DeleteStudentDTO>().ReverseMap();
           
        }

    }
}
