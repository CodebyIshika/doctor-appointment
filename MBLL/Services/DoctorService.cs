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
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo _doctorRepo;

        public DoctorService(IDoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }

        public async Task<List<DoctorDto>> GetAllDoctors()
        {
            var doctors = await _doctorRepo.GetAllDoctors();
            return doctors;
        }

        public async Task<DoctorDto> GetDoctorById(int doctorId)
        {
            var doctor = await _doctorRepo.GetDoctorById(doctorId);
            if (doctor == null)
            {
                throw new Exception($"Doctor with ID {doctorId} not found.");
            }
            return doctor;
        }

        public async Task UpdateDoctor(int doctorId, DoctorDto doctor)
        {
            await _doctorRepo.UpdateDoctor(doctorId, doctor);
        }

        public async Task<List<AppointmentDto>> GetDoctorAppointments(int doctorId)
        {
            var appointments = await _doctorRepo.GetDoctorAppointments(doctorId);
            if (appointments == null)
            {
                throw new Exception($"No appointments found for Doctor with ID {doctorId}.");
            }

            return appointments;
        }
    }
}
