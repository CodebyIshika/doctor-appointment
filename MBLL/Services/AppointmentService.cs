using AutoMapper;
using MAEntities.DTO;
using MBLL.Interface;
using MDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBLL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepo _appointmentRepo;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepo appointmentRepo, IMapper mapper)
        {
            _appointmentRepo = appointmentRepo;
            _mapper = mapper;
        }

        public async Task<AppointmentDto> CreateAppointment(AppointmentDto appointment)
        {
            return await _appointmentRepo.CreateAppointment(appointment);
        }

        public async Task UpdateAppointment(int appointmentId, AppointmentDto appointment)
        {
            await _appointmentRepo.UpdateAppointment(appointmentId, appointment);
        }

        public async Task CancelAppointment(int appointmentId)
        {
            await _appointmentRepo.CancelAppointment(appointmentId);
        }

        public async Task<List<AppointmentDto>> GetDoctorAvailability(int doctorId)
        {
            return await _appointmentRepo.GetDoctorAvailability(doctorId);
        }

        public async Task<List<AppointmentDto>> GetAppointmentHistory()
        {
            return await _appointmentRepo.GetAppointmentHistory();
        }
    }
}
