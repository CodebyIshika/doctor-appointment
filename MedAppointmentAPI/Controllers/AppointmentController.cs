using MAEntities.DTO;
using MBLL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MedAppointmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(AppointmentDto appointmentDto)
        {
            try
            {
                var createdAppointment = await _appointmentService.CreateAppointment(appointmentDto);
                return Ok(createdAppointment);
            }
            catch (Exception)
            {
                return NotFound( "Failed to create appointment.");
            }
        }

        [HttpPut("{appointmentId}")]
        public async Task<IActionResult> UpdateAppointment(int appointmentId, AppointmentDto appointmentDto)
        {
            try
            {
                await _appointmentService.UpdateAppointment(appointmentId, appointmentDto);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound($"Appointment with ID {appointmentId} not found.");
            }
        }

        [HttpDelete("{appointmentId}")]
        public async Task<IActionResult> CancelAppointment(int appointmentId)
        {
            try
            {
                await _appointmentService.CancelAppointment(appointmentId);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound($"Appointment with ID {appointmentId} not found.");
            }
        }

        [HttpGet("doctor-availability/{doctorId}")]
        public async Task<IActionResult> GetDoctorAvailability(int doctorId)
        {
            try
            {
                var doctorAvailability = await _appointmentService.GetDoctorAvailability(doctorId);
                return Ok(doctorAvailability);
            }
            catch (Exception)
            {
                return NotFound($"Doctor with ID {doctorId} not found.");
            }
        }

        [HttpGet("appointment-history")]
        public async Task<IActionResult> GetAppointmentHistory()
        {
            try
            {
                var appointmentHistory = await _appointmentService.GetAppointmentHistory();
                return Ok(appointmentHistory);
            }
            catch (Exception)
            {
                return NotFound("Failed to retrieve appointment history.");
            }
        }
    }
}
