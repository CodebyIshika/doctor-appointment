using MAEntities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBLL.Interface
{
    public interface IPatientService
    {
        Task<List<PatientDto>> GetAllPatients();
        Task<PatientDto> GetPatientById(int patientId);
        Task UpdatePatient(int patientId, PatientDto patient);
    }
}
