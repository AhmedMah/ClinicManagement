using AutoMapper;
using ClinicManagement.Core.Dto;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.Repositories;

namespace ClinicManagement.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Patient, PatientDto>();
            Mapper.CreateMap<City, CityDto>();
            Mapper.CreateMap<Doctor, DoctorDto>();
            Mapper.CreateMap<Specialization, SpecializationDto>();
            //Mapper.CreateMap<DoctorFormViewModel, Doctor>();
        }
    }
}