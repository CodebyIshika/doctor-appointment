using MAEntities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDAL.Interface
{
    public interface IPatientRepo
    {
        Task<List<PatientDto>> GetAllPatients();
        Task<PatientDto> GetPatientById(int patientId);
        Task UpdatePatient(int patientId, PatientDto patientDto);
    }
}
