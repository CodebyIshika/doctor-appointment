using MAEntities.DTO;
using MBLL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MedAppointmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                var patients = await _patientService.GetAllPatients();
                return Ok(patients);
            }
            catch (Exception)
            {
                return NotFound("Failed to retrieve patients.");
            }
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetPatientById(int patientId)
        {
            try
            {
                var patient = await _patientService.GetPatientById(patientId);
                return Ok(patient);
            }
            catch (Exception)
            {
                return NotFound($"Patient with ID {patientId} not found.");
            }
        }

        [HttpPut("{patientId}")]
        public async Task<IActionResult> UpdatePatient(int patientId, PatientDto patientDto)
        {
            try
            {
                await _patientService.UpdatePatient(patientId, patientDto);
                return Ok("Update is successful.");
            }
            catch (Exception)
            {
                return NotFound($"Patient with ID {patientId} not found.");
            }
        }
    }
}
