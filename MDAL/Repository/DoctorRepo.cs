using AutoMapper;
using MAEntities.Context;
using MAEntities.DTO;
using MDAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDAL.Repository
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly MedContext _context;
        private readonly IMapper _mapper;

        public DoctorRepo(MedContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DoctorDto>> GetAllDoctors()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return _mapper.Map<List<DoctorDto>>(doctors);
        }

        public async Task<DoctorDto> GetDoctorById(int doctorId)
        {
            var doctor = await _context.Doctors.FindAsync(doctorId);
            return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task UpdateDoctor(int doctorId, DoctorDto doctorDto)
        {
            var existingDoctor = await _context.Doctors.FindAsync(doctorId);
            if (existingDoctor == null)
            {
                throw new Exception($"Doctor not found. Update failed.");
            }

            _mapper.Map(doctorDto, existingDoctor);

            await _context.SaveChangesAsync();
        }

        public async Task<List<AppointmentDto>> GetDoctorAppointments(int doctorId)
        {
            var doctor = await _context.Doctors.Include(d => d.Appointments)
                         .FirstOrDefaultAsync(d => d.DoctorId == doctorId);
            if (doctor == null)
            {
                throw new Exception($"Doctor with ID {doctorId} not found.");
            }

            var appointments = doctor.Appointments.Select(a => _mapper.Map<AppointmentDto>(a)).ToList();
            return appointments;
        }
    }
}
