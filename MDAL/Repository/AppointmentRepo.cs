using AutoMapper;
using MAEntities.Context;
using MAEntities.DTO;
using MAEntities.Entities;
using MDAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDAL.Repository
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly MedContext _context;
        private readonly IMapper _mapper;

        public AppointmentRepo(MedContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AppointmentDto> CreateAppointment(AppointmentDto appointment)
        {
            var newAppointment = _mapper.Map<Appointment>(appointment);
            _context.Appointments.Add(newAppointment);
            await _context.SaveChangesAsync();
            return _mapper.Map<AppointmentDto>(newAppointment);
        }

        public async Task UpdateAppointment(int appointmentId, AppointmentDto appointment)
        {
            var existingAppointment = await _context.Appointments.FindAsync(appointmentId);
            if (existingAppointment == null)
            {
                throw new Exception($"Appointment with ID {appointmentId} not found.");
            }

            _mapper.Map(appointment, existingAppointment);
            await _context.SaveChangesAsync();
        }

        public async Task CancelAppointment(int appointmentId)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);
            if (appointment == null)
            {
                throw new Exception($"Appointment with ID {appointmentId} not found.");
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AppointmentDto>> GetDoctorAvailability(int doctorId)
        {
            var appointments = await _context.Appointments
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();

            return _mapper.Map<List<AppointmentDto>>(appointments);
        }

        public async Task<List<AppointmentDto>> GetAppointmentHistory()
        {
            var appointments = await _context.Appointments
                .Where(a => a.AppointmentDateTime < DateTime.Now)
                .ToListAsync();

            return _mapper.Map<List<AppointmentDto>>(appointments);
        }
    }
}
