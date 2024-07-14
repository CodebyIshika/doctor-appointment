using MAEntities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBLL.Interface
{
    public interface IDoctorService
    {
        Task<List<DoctorDto>> GetAllDoctors();
        Task<DoctorDto> GetDoctorById(int doctorId);
        Task UpdateDoctor(int doctorId, DoctorDto doctor);
        Task<List<AppointmentDto>> GetDoctorAppointments(int doctorId);
    }
}
