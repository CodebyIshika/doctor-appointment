using MAEntities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBLL.Interface
{
    public interface IAppointmentService
    {
        Task<AppointmentDto> CreateAppointment(AppointmentDto appointment);
        Task UpdateAppointment(int appointmentId, AppointmentDto appointment);
        Task CancelAppointment(int appointmentId);
        Task<List<AppointmentDto>> GetDoctorAvailability(int doctorId);
        Task<List<AppointmentDto>> GetAppointmentHistory();
    }
}
