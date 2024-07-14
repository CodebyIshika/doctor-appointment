using AutoMapper;
using MAEntities.DTO;
using MAEntities.Entities;

namespace MedAppointmentAPI
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Patient, PatientDto>();
            CreateMap<PatientDto, Patient>();

            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorDto, Doctor>();

            CreateMap<Appointment, AppointmentDto>();
            CreateMap<AppointmentDto, Appointment>();
        }
    }
}
