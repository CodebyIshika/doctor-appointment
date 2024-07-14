using MAEntities.DTO;
using MBLL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MedAppointmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                var doctors = await _doctorService.GetAllDoctors();
                return Ok(doctors);
            }
            catch (Exception)
            {
                return NotFound("Failed to retrieve doctors.");
            }
        }

        [HttpGet("{doctorId}")]
        public async Task<IActionResult> GetDoctorById(int doctorId)
        {
            try
            {
                var doctor = await _doctorService.GetDoctorById(doctorId);
                return Ok(doctor);
            }
            catch (Exception)
            {
                return NotFound($"Doctor with ID {doctorId} not found.");
            }
        }

        [HttpPut("{doctorId}")]
        public async Task<IActionResult> UpdateDoctor(int doctorId, DoctorDto doctorDto)
        {
            try
            {
                await _doctorService.UpdateDoctor(doctorId, doctorDto);
                return Ok("Update is successful.");
            }
            catch (Exception)
            {
                return NotFound($"Doctor with ID {doctorId} not found.");
            }
        }

        [HttpGet("{doctorId}/appointments")]
        public async Task<IActionResult> GetDoctorAppointments(int doctorId)
        {
            try
            {
                var appointments = await _doctorService.GetDoctorAppointments(doctorId);
                return Ok(appointments);
            }
            catch (Exception)
            {
                return NotFound($"No appointments found for Doctor with ID {doctorId}.");
            }
        }
    }
}
