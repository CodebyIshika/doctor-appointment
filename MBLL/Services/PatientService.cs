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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo _patientRepo;

        public PatientService(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task<List<PatientDto>> GetAllPatients()
        {
            var patients = await _patientRepo.GetAllPatients();
            return patients;
        }

        public async Task<PatientDto> GetPatientById(int patientId)
        {
            var patient = await _patientRepo.GetPatientById(patientId);
            if (patient == null)
            {
                throw new Exception($"Patient with ID {patientId} not found.");
            }
            return patient;
        }

        public async Task UpdatePatient(int patientId, PatientDto patient)
        {
            await _patientRepo.UpdatePatient(patientId, patient);
        }
    }
}
