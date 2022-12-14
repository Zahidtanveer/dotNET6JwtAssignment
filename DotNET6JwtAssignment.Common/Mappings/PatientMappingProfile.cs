using AutoMapper;
using DotNET6JwtAssignment.Common.Dtos;
using DotNET6JwtAssignment.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNET6JwtAssignment.Common.Mappings
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<Patient, PatientDto>();
            CreateMap<PatientAddUpdateDto, Patient>().ReverseMap();
        }
    }
}
