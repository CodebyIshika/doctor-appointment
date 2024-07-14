using MAEntities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDAL.Interface
{
    public interface IDoctorRepo
    {
        Task<List<DoctorDto>> GetAllDoctors();
        Task<DoctorDto> GetDoctorById(int doctorId);
        Task UpdateDoctor(int doctorId, DoctorDto doctorDto);
        Task<List<AppointmentDto>> GetDoctorAppointments(int doctorId);
    }
}
