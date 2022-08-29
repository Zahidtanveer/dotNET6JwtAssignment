using AutoMapper;
using DotNET6JwtAssignment.Common.Dtos;
using DotNET6JwtAssignment.Common.Models;


namespace DotNET6JwtAssignment.Common.Mappings
{
    public class DoctorMappingProfile : Profile
    {
        public DoctorMappingProfile()
        {
            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorAddUpdateDto, Doctor>().ReverseMap();
        }
    }
}
